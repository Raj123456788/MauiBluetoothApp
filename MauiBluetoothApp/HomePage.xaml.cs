using AndroidX.Lifecycle;
using MauiBluetoothApp.Core;
using MauiBluetoothApp.Interfaces;
using MauiBluetoothApp.Services;
using MauiBluetoothApp.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiBluetoothApp;

public partial class HomePage : ContentPage
{
    private IPermissionBluetooth _permissionService;
    private IBluetoothClient _bleClientService;
    private List<string> _devices;
    //private List<DeviceInfo> _displayList;
    private HomePageViewModel vmodel;

    public HomePage(HomePageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        //InitializeComponent();
        //BindingContext = vm;
        //vmodel = vm;
        //_devices = new List<string>();
        ////_displayList = new List<DeviceInfo>();
    }

    #region ClickHandlers
    #endregion

}
