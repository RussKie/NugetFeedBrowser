// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;

namespace NugetFeedBrowser.Shared.Descriptors;

internal record IndexJsonFeedDescriptor
{
    [JsonProperty(PropertyName = "@context")]
    public object Context { get; set; } = null!;
    public List<IndexJsonResourceDescriptor> Resources { get; set; } = null!;
    public string Version { get; set; } = null!;
}
