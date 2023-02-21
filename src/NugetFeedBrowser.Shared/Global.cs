// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace NugetFeedBrowser.Shared;

public static class Global
{
    internal static HttpClient HttpClient { get; } = new();

    public static void SetAccessToken(string? accessToken)
    {
        HttpClient.DefaultRequestHeaders.Authorization = new("Bearer", accessToken);
    }
}
