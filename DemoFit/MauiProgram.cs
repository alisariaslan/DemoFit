using Microsoft.Extensions.Logging;

using DevExpress.Maui;
using DemoFit.Interface;

namespace DemoFit;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseDevExpress(useLocalization: true)
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();

#endif
		//builder.Services.AddRefitClient<IMyAPI>();

		return builder.Build();
	}
}
