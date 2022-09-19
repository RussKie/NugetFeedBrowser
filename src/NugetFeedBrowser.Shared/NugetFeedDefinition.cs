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
    public string? SearchQueryServiceEndpoint { get; set; }

}
