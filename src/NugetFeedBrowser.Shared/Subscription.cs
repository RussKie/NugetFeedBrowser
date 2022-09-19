// Copyright (c) Igor Velikorossov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml;

namespace NugetFeedBrowser.Shared
{
    public class NugetConfigParser
    {
        private readonly string _nugetConfigPath;

        public NugetConfigParser(string nugetConfigPath)
        {
            _nugetConfigPath = nugetConfigPath;
        }

        public async Task<IReadOnlyList<NugetFeedDefinition>> LoadAsync(CancellationToken cancellationToken = default)
        {
            string content = await File.ReadAllTextAsync(_nugetConfigPath, cancellationToken);
            if (cancellationToken.IsCancellationRequested)
            {
                return Array.Empty<NugetFeedDefinition>();
            }

            XmlDocument doc = new();
            doc.LoadXml(content);

            var nodes = doc.SelectNodes("/configuration/packageSources/add");

            if (nodes.Count == 0)
            {
                return Array.Empty<NugetFeedDefinition>();
            }

            List<NugetFeedDefinition> list = new();
            foreach (XmlNode node in nodes)
            {
                list.Add(new(node.Attributes["key"].Value, node.Attributes["value"].Value));
            }

            return list;
        }
    }

    public record NugetFeedDefinition
    {
        public NugetFeedDefinition(string name, string url)
        {
            Name = name;
            Url = url;

            try
            {
                Uri feedUri = new(url);
                if (feedUri.Scheme == Uri.UriSchemeHttp || feedUri.Scheme == Uri.UriSchemeHttps)
                {
                    ApiBaseUrl = ConvertToApiBaseUrl(feedUri);
                }
            }
            catch { }
        }

        public string Name { get; }
        public string Url { get; }
        public string? ApiBaseUrl { get; }

        private static string? ConvertToApiBaseUrl(Uri feedUri)
        {
            if (feedUri.Host.EndsWith(".azure.com", StringComparison.InvariantCultureIgnoreCase))
            {
            }

            //throw new NotSupportedException($"Host '{feedUri.Host}' is not currently supported.");
            return null;
        }
    }
}

//GET https://feeds.dev.azure.com/{organization}/{project}/_apis/packaging/Feeds/{feedId}/packages?api-version=7.1-preview.1
//GET https://feeds.dev.azure.com/{organization}/{project}/_apis/packaging/Feeds/{feedId}/packages?protocolType={protocolType}&packageNameQuery={packageNameQuery}&normalizedPackageName={normalizedPackageName}&includeUrls={includeUrls}&includeAllVersions={includeAllVersions}&isListed={isListed}&getTopPackageVersions={getTopPackageVersions}&isRelease={isRelease}&includeDescription={includeDescription}&$top={$top}&$skip={$skip}&includeDeleted={includeDeleted}&isCached={isCached}&directUpstreamId={directUpstreamId}&api-version=7.1-preview.1
