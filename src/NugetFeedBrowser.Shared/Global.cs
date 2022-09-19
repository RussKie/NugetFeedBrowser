// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace NugetFeedBrowser.Shared;

internal static class Global
{
    internal static HttpClient HttpClient { get; } = new();
}
