using MauiBluetoothApp.ViewModels;


namespace MauiBluetoothApp;

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
		// Glad to see DI added by Microsoft here.
		builder.Services.AddSingleton<MainPage>();        
        builder.Services.AddSingleton<MainViewModel>();		


		return builder.Build();
	}
}
