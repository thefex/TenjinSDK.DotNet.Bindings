namespace TenjinSDK.Sample.Services;

/// <summary>
/// Thin cross-platform facade over the native Tenjin SDK bindings so the shared
/// UI can drive the iOS and Android SDKs through one API.
/// </summary>
public interface ITenjinService
{
    /// <summary>Initializes the SDK with the given API key and fires the connect call.</summary>
    void Initialize(string apiToken);

    /// <summary>Sends a named analytics event.</summary> 
    void SendEvent(string name);

    /// <summary>Sends a named analytics event with an integer value.</summary>
    void SendEvent(string name, int value);

    /// <summary>Reports an in-app purchase / transaction.</summary>
    void SendTransaction(string productId, string currencyCode, int quantity, double unitPrice);

    /// <summary>Associates a customer-defined user id with subsequent events.</summary>
    void SetCustomerUserId(string userId);

    /// <summary>Returns the analytics installation id assigned by Tenjin.</summary>
    string? GetAnalyticsInstallationId();

    /// <summary>The native Tenjin SDK version backing this platform.</summary>
    string SdkVersion { get; }
}
