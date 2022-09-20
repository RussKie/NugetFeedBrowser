// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Diagnostics;
using System.Drawing;
using Newtonsoft.Json;
using NugetFeedBrowser.Shared.Descriptors;

namespace NugetFeedBrowser.Shared;

public class NuGetSearch
{
    // https://learn.microsoft.com/nuget/api/search-query-service-resource
    public async Task<IReadOnlyList<PackageDataDescriptor>> FindPackageAsync(NugetFeedDefinition feedDefinition, string packageName)
    {
        if (string.IsNullOrWhiteSpace(packageName) || string.IsNullOrWhiteSpace(feedDefinition.SearchQueryServiceEndpoint))
        {
            return Array.Empty<PackageDataDescriptor>();
        }

        try
        {
            string query = $"{feedDefinition.SearchQueryServiceEndpoint}?q={packageName}&prerelease=true&semVerLevel=2.0.0";
            string responseBody = await Global.HttpClient.GetStringAsync(query);

            FindPackageResultDescriptor descriptor = JsonConvert.DeserializeObject<FindPackageResultDescriptor>(responseBody)!;

            List<Task> tasks = new();
            foreach (var item in descriptor.Data)
            {
                item.WebGalleryUri = feedDefinition.WebGalleryUri;

                tasks.Add(Task.Run(async () =>
                {
                    if (string.IsNullOrWhiteSpace(item.IconUrl))
                    {
                        item.Icon = null;
                        return;
                    }

                    var imageByteArray = await Global.HttpClient.GetByteArrayAsync(item.IconUrl);
                    item.Icon = Image.FromStream(new MemoryStream(imageByteArray));
                }));

                await Task.WhenAll(tasks);
            }

            return descriptor.Data;

        }
        catch (HttpRequestException ex)
        {
            Debug.WriteLine(ex.Message);
            return Array.Empty<PackageDataDescriptor>();
        }
    }
}
