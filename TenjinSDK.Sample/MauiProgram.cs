using Microsoft.Extensions.Logging;
using TenjinSDK.Sample.Services;

namespace TenjinSDK.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// The platform-specific TenjinService is selected at compile time by file name
		// (TenjinService.iOS.cs / TenjinService.Android.cs).
		builder.Services.AddSingleton<ITenjinService, TenjinService>();
		builder.Services.AddSingleton<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
