using System.Globalization;
using Foundation;
// Alias the binding class: the bare name `TenjinSDK` would otherwise bind to the
// app's own `TenjinSDK.*` namespace instead of the SDK type.
using Tenjin = TenjinSDKBindings.TenjinSDK;

namespace TenjinSDK.Sample.Services;

/// <summary>iOS implementation backed by the TenjinSDK.iOS binding.</summary>
public class TenjinService : ITenjinService
{
    public void Initialize(string apiToken)
    {
        // Enable Tenjin's verbose/debug logging before init so the whole session is
        // traced, and mirror the SDK's log output into the .NET debug console.
        Tenjin.SetLogHandler(message =>
            System.Diagnostics.Debug.WriteLine($"[Tenjin] {message}"));
        Tenjin.DebugLogs();
        Tenjin.VerboseLogs();

        Tenjin.Initialize(apiToken);
        Tenjin.Connect();
    }

    public void SendEvent(string name) => Tenjin.SendEventWithName(name);

    public void SendEvent(string name, int value) => Tenjin.SendEventWithName(name, value);

    public void SendTransaction(string productId, string currencyCode, int quantity, double unitPrice) =>
        Tenjin.TransactionWithProductName(productId, currencyCode, quantity,
            new NSDecimalNumber(unitPrice.ToString(CultureInfo.InvariantCulture)));

    public void SetCustomerUserId(string userId) => Tenjin.SetCustomerUserId(userId);

    public string? GetAnalyticsInstallationId() => Tenjin.AnalyticsInstallationId;

    public string SdkVersion => Tenjin.SdkVersion;
}
