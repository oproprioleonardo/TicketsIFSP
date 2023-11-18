using Camera.MAUI;
using Microsoft.Extensions.Logging;
using TicketsIFSP.Handlers;
using TicketsIFSP.Mock;
using TicketsIFSP.Pages;
using TicketsIFSP.Providers;
using TicketsIFSP.Views;

namespace TicketsIFSP;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiCameraView()
            .UseMauiApp<App>()
			.RegisterAppServices()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		
		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IGuestProvider, HttpGuestProvider>();
		mauiAppBuilder.Services.AddSingleton<IEventProvider, HttpEventProvider>();
		mauiAppBuilder.Services.AddSingleton<IGuestHandler, HttpGuestHandler>();
		mauiAppBuilder.Services.AddSingleton<MainPage>();
		mauiAppBuilder.Services.AddSingleton<EventsPage>();
		mauiAppBuilder.Services.AddTransient<QrCodeReaderPage>();
		mauiAppBuilder.Services.AddTransient<PersonDataPage>();
        return mauiAppBuilder;
    }
}
