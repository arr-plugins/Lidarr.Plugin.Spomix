# main.py

import sys
from plugin_interface import PluginInterface
from spotify_client import SpotifyClient
from utils import setup_logging

class LidarrSpotifyPlugin(PluginInterface):
    def __init__(self):
        self.plugin_name = "Lidarr Spotify Plugin"
        self.plugin_version = "1.0.0"
        self.spotify_client = SpotifyClient()
        setup_logging()

    def get_plugin_name(self):
        return self.plugin_name

    def get_plugin_version(self):
        return self.plugin_version

    def handle_request(self, request):
        # Handle incoming requests from Lidarr
        if request['type'] == 'search':
            return self.spotify_client.search_track(request['query'])
        elif request['type'] == 'download':
            return self.spotify_client.download_track(request['track_id'])
        else:
            return {"error": "Unknown request type"}

def main():
    plugin = LidarrSpotifyPlugin()
    print(f"Starting {plugin.get_plugin_name()} v{plugin.get_plugin_version()}")
    # Here you would typically start the plugin's main loop or server

if __name__ == "__main__":
    main()