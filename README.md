# TenjinSDK .NET bindings

Unofficial .NET bindings for the [Tenjin](https://www.tenjin.com/) mobile SDKs.
This package is **not affiliated with Tenjin**.

| Platform | Project | Native SDK | NuGet id |
| --- | --- | --- | --- |
| iOS | [`TenjinSDK.iOS`](TenjinSDK.iOS) | [tenjin-ios-sdk 1.17.1](https://github.com/tenjin/tenjin-ios-sdk/releases/tag/1.17.1) | `TenjinSDK.DotNet.Bindings` |
| Android | [`TenjinSDK.Android`](TenjinSDK.Android) | [tenjin-android-sdk 1.20.0](https://github.com/tenjin/tenjin-android-sdk/releases/tag/1.20.0) | `TenjinSDK.DotNet.Bindings.Android` |

Both target **.NET 10** (`net10.0-ios` / `net10.0-android`).

## Sample app

[`TenjinSDK.Sample`](TenjinSDK.Sample) is a .NET MAUI app targeting iOS and Android.
It wires the native SDK behind a small cross-platform `ITenjinService`
(see [`Platforms/iOS`](TenjinSDK.Sample/Platforms/iOS/TenjinService.cs) and
[`Platforms/Android`](TenjinSDK.Sample/Platforms/Android/TenjinService.cs)) and exposes
buttons to initialize/connect, send events and transactions, set a customer user id,
and read the analytics installation id.

```bash
dotnet build TenjinSDK.Sample/TenjinSDK.Sample.csproj -f net10.0-android
dotnet build TenjinSDK.Sample/TenjinSDK.Sample.csproj -f net10.0-ios
```

## Android runtime dependencies

The Android binding declares the SDK's Maven dependencies (kotlin-stdlib, Room,
Gson, Play Install Referrer) so consuming apps pick them up transitively. Google
Play Billing and Play Services Ad-ID are accessed reflectively by the SDK and are
not declared — add them in the consuming app if you use those features.
