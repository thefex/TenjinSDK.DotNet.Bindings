# TenjinSDK .NET bindings

Unofficial .NET bindings for the [Tenjin](https://www.tenjin.com/) mobile attribution SDKs.
This package is **not affiliated with Tenjin**.

| Platform | Project | Native SDK | NuGet id |
| --- | --- | --- | --- |
| iOS | [`TenjinSDK.iOS`](TenjinSDK.iOS) | [tenjin-ios-sdk 1.17.2](https://github.com/tenjin/tenjin-ios-sdk/releases/tag/1.17.2) | `TenjinSDK.DotNet.Bindings` |
| Android | [`TenjinSDK.Android`](TenjinSDK.Android) | [tenjin-android-sdk 1.21.0](https://github.com/tenjin/tenjin-android-sdk/releases/tag/1.21.0) | `TenjinSDK.DotNet.Bindings.Android` |

Both target **.NET 10** (`net10.0-ios` / `net10.0-android`).

## Install

```bash
dotnet add package TenjinSDK.DotNet.Bindings          # iOS
dotnet add package TenjinSDK.DotNet.Bindings.Android  # Android
```

## Usage

The native class is `TenjinSDK` on both platforms, but the shape differs: iOS is
**static**, Android is **instance-based** (obtained with a `Context`).

### iOS — namespace `TenjinSDKBindings`

```csharp
using TenjinSDKBindings;

TenjinSDK.Initialize("<API_KEY>");
TenjinSDK.Connect();

TenjinSDK.SendEventWithName("test_event");
TenjinSDK.SendEventWithName("level_up", 5);
TenjinSDK.TransactionWithProductName("com.example.product", "USD", 1,
    new Foundation.NSDecimalNumber("4.99"));

var installId = TenjinSDK.AnalyticsInstallationId;
```

### Android — namespace `Com.Tenjin.Android`

```csharp
using Com.Tenjin.Android;

var tenjin = TenjinSDK.GetInstance(context, "<API_KEY>"); // e.g. Android.App.Application.Context
tenjin.Connect();

tenjin.EventWithName("test_event");
tenjin.EventWithNameAndValue("level_up", 5);
tenjin.Transaction("com.example.product", "USD", 1, 4.99);

var installId = tenjin.AnalyticsInstallationId;
```

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

Notable bits the sample demonstrates:

- **Logging** — iOS enables Tenjin's `DebugLogs()`/`VerboseLogs()` and mirrors SDK
  output into the .NET debug console via `SetLogHandler`. The Android SDK has no
  logging toggle; it writes to logcat under the `Tenjin` tag by default.
- **Advertising ID (GAID)** — Tenjin reads the GAID via reflection. The sample pulls
  `play-services-ads-identifier` (plus `basement`/`tasks`) straight from Google's
  Maven repo as runtime-only libraries and adds the `com.google.android.gms.permission.AD_ID`
  manifest permission. (The `Xamarin.GooglePlayServices.*` NuGet bindings are avoided
  because they emit duplicate `com.google.android.gms.*` manifests the .NET 10 manifest
  merger rejects.)

> If a Rider partial build fails with `CS0006 … TenjinSDK.iOS.dll could not be found`,
> run **Build Solution** once — the fast "surface heuristics" build can skip building
> the binding for the device RID before compiling the app.

## Android runtime dependencies

The Android binding declares the SDK's Maven dependencies so consuming apps pick them
up transitively:

- `org.jetbrains.kotlin:kotlin-stdlib` (the SDK is partly Kotlin)
- `androidx.room:room-runtime` (pinned to 2.5.x to stay ABI-compatible with the SDK's
  Room-generated code)
- `com.google.code.gson:gson`
- `com.android.installreferrer:installreferrer`

Google Play Billing and Play Services Ad-ID / App Set are accessed reflectively by the
SDK and are **not** declared — add them in the consuming app if you use those features
(see the sample for the GAID setup).

## Building

```bash
dotnet build Bindings.sln                              # everything
dotnet build TenjinSDK.iOS/TenjinSDK.iOS.csproj -c Release       # iOS nupkg
dotnet build TenjinSDK.Android/TenjinSDK.Android.csproj -c Release # Android nupkg
```

A repo-local [`nuget.config`](nuget.config) clears any machine-wide local feeds so the
solution restores reproducibly from nuget.org.
