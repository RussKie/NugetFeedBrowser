// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace NugetFeedBrowser.Shared.Descriptors;

// https://learn.microsoft.com/nuget/api/search-query-service-resource
public record PackageDataVersionDescriptor
{
    [JsonProperty(PropertyName = "@id")]
    public string Id { get; set; } = null!;
    public string Version { get; set; } = null!;
    public int Downloads { get; set; }
}
