// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Drawing;

namespace NugetFeedBrowser.Shared.Descriptors;

// https://learn.microsoft.com/nuget/api/search-query-service-resource
public record PackageDataDescriptor
{
    public string Id { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string? Description { get; set; }
    public List<PackageDataVersionDescriptor> Versions { get; set; } = null!;
    public List<string>? Authors { get; set; }
    public string? IconUrl { get; set; }
    public Image? Icon { get; set; }
    public string? LicenseUrl { get; set; }
    public List<string>? Owners { get; set; }
    public string? ProjectUrl { get; set; }
    public string? Registration { get; set; }
    public string? Summary { get; set; }
    public string? Title { get; set; }
    public long? TotalDownloads { get; set; }
    public string? WebGalleryUri { get; set; }
}
