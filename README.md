# MRQ

A **.NET MAUI** (net8.0) app targeting Android, iOS, Mac Catalyst and Windows from one codebase.

The interesting part: **`Controls/CircleGraph`** — a custom donut-chart control that subclasses `GraphicsView`, implements `IDrawable`, and renders its sections directly to the MAUI `ICanvas`. No charting library is involved.

## Project layout

```
MRQAndroid/
├── Controls/            CircleGraph (custom GraphicsView/IDrawable control)
├── Platforms/           Android · iOS · MacCatalyst · Windows · Tizen heads
├── AppShell.xaml        Shell-based navigation
└── MauiProgram.cs       Host builder / DI registration
```

## Building

From the repository root:

```bash
dotnet build MRQAndroid/MRQAndroid.csproj \
  -f net8.0-android \
  -p:TargetFrameworks=net8.0-android
```

Requires the .NET 8 SDK, the `maui-android` workload, JDK 17, and the Android SDK.
`TargetFrameworks` keeps command-line builds on Linux from trying to restore the
Apple platform heads.

## Status

Active WIP — UI iterations happen on feature branches; `main` holds the stable scaffold.

## License

See [LICENSE](LICENSE).
