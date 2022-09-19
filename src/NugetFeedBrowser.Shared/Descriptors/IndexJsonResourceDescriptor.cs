// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace NugetFeedBrowser.Shared.Descriptors;

internal record IndexJsonResourceDescriptor
{
    [JsonProperty(PropertyName = "@id")]
    public string Id { get; set; } = null!;
    [JsonProperty(PropertyName = "@type")]
    public string Type { get; set; } = null!;
}
