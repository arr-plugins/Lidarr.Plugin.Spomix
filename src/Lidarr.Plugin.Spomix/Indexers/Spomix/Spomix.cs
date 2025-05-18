using System;
using NLog;
using NzbDrone.Common.Cache;
using NzbDrone.Common.Http;
using NzbDrone.Core.Configuration;
using NzbDrone.Core.Download.Clients.Spomix;
using NzbDrone.Core.Parser;

namespace NzbDrone.Core.Indexers.Spomix
{
    public class Spomix : HttpIndexerBase<SpomixIndexerSettings>
    {
        public override string Name => "Spomix";
        public override string Protocol => nameof(SpomixDownloadProtocol);
        public override bool SupportsRss => true;
        public override bool SupportsSearch => true;
        public override int PageSize => 100;
        public override TimeSpan RateLimit => new TimeSpan(0);

        private readonly ICached<SpomixUser> _userCache;
        private readonly ISpomixProxy _spomixProxy;

        public Spomix(ICacheManager cacheManager,
            ISpomixProxy spomixProxy,
            IHttpClient httpClient,
            IIndexerStatusService indexerStatusService,
            IConfigService configService,
            IParsingService parsingService,
            Logger logger)
            : base(httpClient, indexerStatusService, configService, parsingService, logger)
        {
            _userCache = cacheManager.GetCache<SpomixUser>(typeof(SpomixProxy), "user");
            _spomixProxy = spomixProxy;
        }

        public override IIndexerRequestGenerator GetRequestGenerator()
        {
            return new SpomixRequestGenerator()
            {
                Settings = Settings,
                Logger = _logger
            };
        }

        public override IParseIndexerResponse GetParser()
        {
            _spomixProxy.Authenticate(Settings);

            return new SpomixParser()
            {
                User = _userCache.Find(Settings.BaseUrl)
            };
        }
    }
}
