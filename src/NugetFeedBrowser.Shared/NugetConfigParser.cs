// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Xml;
using Newtonsoft.Json;
using NugetFeedBrowser.Shared.Descriptors;

namespace NugetFeedBrowser.Shared;

public class NugetConfigParser
{
    public async Task<IReadOnlyList<NugetFeedDefinition>> LoadAsync(string nugetConfigPath, CancellationToken cancellationToken = default)
    {
        string content = await File.ReadAllTextAsync(nugetConfigPath, cancellationToken);
        if (cancellationToken.IsCancellationRequested)
        {
            return Array.Empty<NugetFeedDefinition>();
        }

        XmlDocument doc = new();
        doc.LoadXml(content);

        var nodes = doc.SelectNodes("/configuration/packageSources/add");

        if (nodes.Count == 0)
        {
            return Array.Empty<NugetFeedDefinition>();
        }

        List<Task> tasks = new();
        List<NugetFeedDefinition> list = new();
        foreach (XmlNode node in nodes)
        {
            NugetFeedDefinition feedDefinition = new(node.Attributes["key"].Value, node.Attributes["value"].Value);
            list.Add(feedDefinition);

            // Parallelise the endpoint resolution
            tasks.Add(LoadSearchEndpointAsync(feedDefinition));
        }

        await Task.WhenAll(tasks);

        return list;
    }

    private static async Task LoadSearchEndpointAsync(NugetFeedDefinition nugetFeed)
    {
        string responseBody;
        try
        {
            responseBody = await Global.HttpClient.GetStringAsync(nugetFeed.Url);
        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine(ex.Message);
            return;
        }

        if (responseBody.StartsWith("<?xml"))
        {
            Debug.WriteLine($"{nugetFeed.Url} responded with XML!");
            nugetFeed.IsSupported = false;
            return;
        }

        IndexJsonFeedDescriptor descriptor = JsonConvert.DeserializeObject<IndexJsonFeedDescriptor>(responseBody)!;

        // Generic
        nugetFeed.SearchQueryServiceEndpoint = descriptor.Resources.FirstOrDefault(x => x.Type.StartsWith("SearchQueryService"))?.Id;
        string? packageBaseAddress = descriptor.Resources.FirstOrDefault(x => x.Type.StartsWith("PackageBaseAddress"))?.Id;

        // AzDO
        string? vssBaseUrl = descriptor.Resources.FirstOrDefault(x => x.Type.StartsWith("VssBaseUrl"))?.Id;
        string? azureDevOpsProjectId = descriptor.Resources.FirstOrDefault(x => x.Type.StartsWith("AzureDevOpsProjectId"))?.Label;

        // NuGet
        string? packageDetailsUriTemplate = descriptor.Resources.FirstOrDefault(x => x.Type.StartsWith("PackageDetailsUriTemplate"))?.Id;

        if (!string.IsNullOrWhiteSpace(packageDetailsUriTemplate))
        {
            nugetFeed.WebGalleryUri = packageDetailsUriTemplate.Replace("{id}", "{0}").Replace("{version}", "{1}").Replace("?_src=template", "");
        }
        else if (!string.IsNullOrWhiteSpace(vssBaseUrl) && !string.IsNullOrWhiteSpace(azureDevOpsProjectId))
        {
            // HACK: DevDiv specific??
            nugetFeed.WebGalleryUri = $"{vssBaseUrl.Replace("pkgs.dev.azure.com", "dev.azure.com")}{azureDevOpsProjectId}/_artifacts/feed/{nugetFeed.Name}/NuGet/{{0}}/overview/{{1}}/";
        }
        else
        {
            Debug.WriteLine($"Support for {nugetFeed.Url} is not implemented");
            nugetFeed.IsSupported = false;
        }
    }
}
