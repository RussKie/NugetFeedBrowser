// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using NugetFeedBrowser.Shared.Descriptors;

namespace NugetFeedBrowser.Shared;

internal record FindPackageResultDescriptor
{
    [JsonProperty(PropertyName = "@context")]
    public object Context { get; set; } = null!;
    public List<PackageDataDescriptor> Data { get; set; } = null!;
    public DateTime LastReopen { get; set; }
    public string Index { get; set; } = null!;
}