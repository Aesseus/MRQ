# MRQ

A **.NET MAUI** (net8.0) app targeting Android, iOS, Mac Catalyst and Windows from one codebase.

The interesting part: **`Controls/CircleGraph`** — a custom circular graph control drawn directly on the MAUI `ICanvas` via an `IDrawable`, fed by a pluggable `DataProvider` delegate. No charting library, just `Microsoft.Maui.Graphics`.

## Project layout

```
MRQAndroid/
├── Controls/            CircleGraph + CircleGraphDrawable (custom-drawn control)
├── Platforms/           Android · iOS · MacCatalyst · Windows · Tizen heads
├── AppShell.xaml        Shell-based navigation
└── MauiProgram.cs       Host builder / DI registration
```

## Building

```bash
dotnet build MRQAndroid.sln -f net8.0-android
```

Requires the .NET 8 SDK with the `maui` workload (`dotnet workload install maui`).

## Status

Active WIP — UI iterations happen on feature branches; `main` holds the stable scaffold.

## License

See [LICENSE](LICENSE).
