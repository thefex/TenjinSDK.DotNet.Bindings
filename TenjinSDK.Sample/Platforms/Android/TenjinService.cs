using Com.Tenjin.Android;

namespace TenjinSDK.Sample.Services;

/// <summary>Android implementation backed by the TenjinSDK.Android binding.</summary>
public class TenjinService : ITenjinService
{
    // The Android SDK has no runtime version accessor (only wrapper/plugin version),
    // so we surface the bound SDK version that this binding ships.
    private const string BoundSdkVersion = "1.21.0";

    private global::Com.Tenjin.Android.TenjinSDK? _instance;

    private global::Com.Tenjin.Android.TenjinSDK Instance =>
        _instance ?? throw new InvalidOperationException("Call Initialize(apiToken) first.");

    public void Initialize(string apiToken)
    {
        // The Android Tenjin SDK has no logging toggle — it writes to logcat by
        // default (filter on the "Tenjin" tag), so there is nothing to enable here.
        var context = global::Android.App.Application.Context;
        _instance = global::Com.Tenjin.Android.TenjinSDK.GetInstance(context, apiToken)
            ?? throw new InvalidOperationException("Tenjin SDK failed to initialize.");
        _instance.Connect();
    }

    public void SendEvent(string name) => Instance.EventWithName(name);

    public void SendEvent(string name, int value) => Instance.EventWithNameAndValue(name, value);

    public void SendTransaction(string productId, string currencyCode, int quantity, double unitPrice) =>
        Instance.Transaction(productId, currencyCode, quantity, unitPrice);

    public void SetCustomerUserId(string userId) => Instance.CustomerUserId = userId;

    public string? GetAnalyticsInstallationId() => Instance.AnalyticsInstallationId;

    public string SdkVersion => BoundSdkVersion;
}
