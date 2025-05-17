# Lidarr Spotify Plugin

A Lidarr plugin for searching and downloading music from Spotify, inspired by the Deemix plugin (for Deezer).

## Features

- Search for tracks, albums, and artists on Spotify
- Download tracks directly from Spotify (where permitted)
- Integrates with Lidarr's plugin system

## Requirements

- .NET 8.0 SDK
- A Spotify Developer account and API credentials

## Building

```sh
dotnet restore Lidarr.SpotifyPlugin/Lidarr.SpotifyPlugin.csproj
dotnet build Lidarr.SpotifyPlugin/Lidarr.SpotifyPlugin.csproj --configuration Release
dotnet pack Lidarr.SpotifyPlugin/Lidarr.SpotifyPlugin.csproj --configuration Release --output .
```

## Usage

1. Configure your Spotify API credentials in the plugin settings.
2. Install the `.nupkg` file in Lidarr via the plugin manager.
3. Use Lidarr to search and download music from Spotify.

## Development

- Main plugin code is in `Lidarr.SpotifyPlugin/`
- Uses [SpotifyAPI-NET](https://github.com/JohnnyCrazy/SpotifyAPI-NET) for Spotify integration

## Contributing

Pull requests are welcome! Please open an issue first to discuss major changes.

## License

MIT License
