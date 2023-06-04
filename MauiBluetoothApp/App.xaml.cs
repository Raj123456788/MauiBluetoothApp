using MauiBluetoothApp.Core;

namespace MauiBluetoothApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

	

        // Load the dependency injection
        Resolver.Build();
        MainPage = new AppShell();

    }
}
