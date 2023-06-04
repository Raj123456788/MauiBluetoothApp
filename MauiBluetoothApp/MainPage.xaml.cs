using MauiBluetoothApp.Core;
using MauiBluetoothApp.Interfaces;
using MauiBluetoothApp.Services;
using MauiBluetoothApp.ViewModels;
using MauiBluetoothApp.Models;
using Microsoft.Maui.Controls;

namespace MauiBluetoothApp;

public partial class MainPage : ContentPage
{

    private MainViewModel vmodel;

    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vmodel = vm;

    }



    public class DeviceInfo
    {
        public string Name { get; set; }

        public string Details { get; set; }

    }

    private void bleListview_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var device = (Helpers.DeviceCandidate)e.Item;
        Console.WriteLine("DEBUG bleListview_ItemTapped Connect text | " + device.Name);
        vmodel.Status = "Connecting";
        vmodel.ConnectToDevice(device.Name);
    }

}
