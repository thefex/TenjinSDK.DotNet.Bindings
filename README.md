# TenjinSDK .NET bindings

Unofficial .NET bindings for the [Tenjin](https://www.tenjin.com/) mobile attribution SDKs.
This package is **not affiliated with Tenjin**.

| Platform | Project | Native SDK | NuGet id |
| --- | --- | --- | --- |
| iOS | [`TenjinSDK.iOS`](TenjinSDK.iOS) | [tenjin-ios-sdk 1.20.1](https://github.com/tenjin/tenjin-ios-sdk/releases/tag/1.20.1) | `TenjinSDK.DotNet.Bindings` |
| Android | [`TenjinSDK.Android`](TenjinSDK.Android) | [tenjin-android-sdk 2.0.2](https://github.com/tenjin/tenjin-android-sdk/releases/tag/2.0.2) | `TenjinSDK.DotNet.Bindings.Android` |

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

// Re-engagement deeplinks: forward the URL the app was opened with.
// AppDelegate-only apps get cold launches captured automatically; scene-based
// apps should forward from the UIScene delegate callbacks too.
TenjinSDK.HandleOpenUrl(url);            // from OpenUrl / ContinueUserActivity
TenjinSDK.HandleOpenUrlString("app://x"); // raw-string variant, safe before init

// Opt in to automatic StoreKit 2 subscription / one-time purchase tracking (iOS 16+).
TenjinSDK.EnableAutoSubscriptionTracking();
TenjinSDK.EnableAutoPurchaseTracking();
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

// Re-engagement deeplinks: cold launches are captured automatically; forward
// warm opens (OnNewIntent) so they are reported too.
tenjin.HandleOpenIntent(intent);   // or tenjin.HandleOpenUrl(url)

// Opt in to automatic Play Billing subscription / purchase tracking. The SDK reaches
// the Play Billing library reflectively, so the consuming app must ship it.
tenjin.EnableAutoSubscriptionTracking();
tenjin.EnableAutoPurchaseTracking();
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

Since tenjin-android-sdk 2.0.0 the AAR ships R8-minified. The binding exposes only the
API that Tenjin's own consumer ProGuard rules keep stable — `TenjinSDK`, its callback
interfaces, `Transaction`, `AdvertiserInfo`, `UserProfileData` and `AppStoreType` —
while minified internals (`EventKey`, `EventName`, `UserProfileManager`, the `Async*`
tasks) are no longer bound.

## Building

```bash
dotnet build Bindings.sln                              # everything
dotnet build TenjinSDK.iOS/TenjinSDK.iOS.csproj -c Release       # iOS nupkg
dotnet build TenjinSDK.Android/TenjinSDK.Android.csproj -c Release # Android nupkg
```

A repo-local [`nuget.config`](nuget.config) clears any machine-wide local feeds so the
solution restores reproducibly from nuget.org.

The .NET for iOS workload pins an Xcode version (27.1.x needs Xcode 27.1). If a different
Xcode is selected on the machine, point the build at the right one:

```bash
dotnet build TenjinSDK.Sample/TenjinSDK.Sample.csproj -f net10.0-ios -p:XcodeLocation=/Applications/Xcode27_1.app
```
