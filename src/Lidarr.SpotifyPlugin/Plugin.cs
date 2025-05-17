using System;
using System.Threading.Tasks;

namespace Lidarr.SpotifyPlugin
{
    public class Plugin
    {
        public string Name => "Lidarr Spotify Plugin";
        public string Version => "1.0.0";

        public async Task<string> SearchTrackAsync(string query)
        {
            // Call SpotifyClient to search for a track
            return await SpotifyClient.SearchTrackAsync(query);
        }

        public async Task<string> DownloadTrackAsync(string trackId)
        {
            // Call SpotifyClient to download a track
            return await SpotifyClient.DownloadTrackAsync(trackId);
        }
    }
}
