// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace NugetFeedBrowser.Shared;

public record NugetFeedDefinition
{
    public NugetFeedDefinition(string name, string url)
    {
        Name = name;
        Url = url;
    }

    public string Name { get; }
    public string Url { get; }

    public bool IsSupported { get; set; } = true;

    public string? SearchQueryServiceEndpoint { get; set; }
    public string? WebGalleryUri { get; set; }

    /// <summary>
    ///  The error message that may have been received while retrieving the feed information.
    /// </summary>
    public string? ErrorMessage { get; set; }
}
