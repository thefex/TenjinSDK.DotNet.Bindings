using TenjinSDK.Sample.Services;

namespace TenjinSDK.Sample;

public partial class MainPage : ContentPage
{
	private readonly ITenjinService _tenjin;
	private bool _initialized;

	public MainPage(ITenjinService tenjin)
	{
		InitializeComponent();
		_tenjin = tenjin;
		SdkVersionLabel.Text = $"SDK version: {_tenjin.SdkVersion}";
	}

	private void OnInitializeClicked(object? sender, EventArgs e) => Run("Initialize", () =>
	{
		var token = ApiTokenEntry.Text?.Trim();
		if (string.IsNullOrEmpty(token))
			throw new InvalidOperationException("Enter a Tenjin API key first.");

		_tenjin.Initialize(token);
		_initialized = true;
		return "Initialized and connected.";
	});

	private void OnSendEventClicked(object? sender, EventArgs e) => Run("Send event", () =>
	{
		RequireInit();
		_tenjin.SendEvent("test_event");
		return "Sent event 'test_event'.";
	});

	private void OnSendEventWithValueClicked(object? sender, EventArgs e) => Run("Send event w/ value", () =>
	{
		RequireInit();
		_tenjin.SendEvent("level_up", 5);
		return "Sent event 'level_up' = 5.";
	});

	private void OnSendTransactionClicked(object? sender, EventArgs e) => Run("Send transaction", () =>
	{
		RequireInit();
		_tenjin.SendTransaction("com.example.product", "USD", 1, 4.99);
		return "Sent transaction com.example.product ($4.99).";
	});

	private void OnSetUserIdClicked(object? sender, EventArgs e) => Run("Set user id", () =>
	{
		RequireInit();
		_tenjin.SetCustomerUserId("sample-user-123");
		return "Customer user id set to 'sample-user-123'.";
	});

	private void OnGetAnalyticsIdClicked(object? sender, EventArgs e) => Run("Get analytics id", () =>
	{
		RequireInit();
		var id = _tenjin.GetAnalyticsInstallationId();
		return $"Analytics installation id: {id ?? "(null)"}";
	});

	private void RequireInit()
	{
		if (!_initialized)
			throw new InvalidOperationException("Tap 'Initialize + Connect' first.");
	}

	private void Run(string action, Func<string> work)
	{
		try
		{
			StatusLabel.Text = work();
		}
		catch (Exception ex)
		{
			StatusLabel.Text = $"{action} failed: {ex.Message}";
		}
	}
}
