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

        List<NugetFeedDefinition> list = new();
        foreach (XmlNode node in nodes)
        {
            NugetFeedDefinition feedDefinition = new(node.Attributes["key"].Value, node.Attributes["value"].Value);
            feedDefinition.SearchQueryServiceEndpoint = await LoadSearchEndpointAsync(feedDefinition.Url);

            list.Add(feedDefinition);
        }

        return list;
    }
    private static async Task<string?> LoadSearchEndpointAsync(string feedUri)
    {
        try
        {
            string responseBody = await Global.HttpClient.GetStringAsync(feedUri);

            IndexJsonFeedDescriptor descriptor = JsonConvert.DeserializeObject<IndexJsonFeedDescriptor>(responseBody)!;
            return descriptor.Resources.SingleOrDefault(x => x.Type.StartsWith("SearchQueryService"))?.Id;

        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

}
