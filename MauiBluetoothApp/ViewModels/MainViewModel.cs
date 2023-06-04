using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBluetoothApp.Core;
using MauiBluetoothApp.Helpers;
using MauiBluetoothApp.Interfaces;
using MauiBluetoothApp.Models;
using MauiBluetoothApp.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBluetoothApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private IBluetoothClient _bleClientService;
        public MainViewModel()
        {
            Items = new ObservableCollection<DeviceCandidate>();


        }
        #region Properties

        [ObservableProperty]
        ObservableCollection<DeviceCandidate> items;



        private bool IsBusy { get; set; } = false;

        [ObservableProperty]
        string status = Constants.Constants.notConnected;
        #endregion
        #region CallBack
        private void FoundDevice(string device, string address)
        {
            {
                Console.WriteLine("DEBUG | FoundDevice" + device + address);

                Items.Add(new Helpers.DeviceCandidate { Name = device, Details = address });

            }
        }
        #endregion
        #region HelperMethods
        private async Task<PermissionStatus> CheckBleStatusAsync()
        {

            var status = PermissionStatus.Unknown;


            try
            {
                if (DeviceInfo.Version.Major >= 12)
                {
                    status = await Permissions.CheckStatusAsync<BleConnectPermission>();
                   
                }
                else
                {
                    status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                   
                }
                return status;
            }
            catch (Exception)
            {

                await Shell.Current.DisplayAlert(Constants.Constants.unableToConnectTitle, Constants.Constants.connectedTo, Constants.Constants.ok);
                return status;
            }
        }
        #endregion


        #region Command
        /// <summary>
        /// Request the Bluetooth Permission.
        /// </summary>
        /// <returns></returns>

        [RelayCommand]
        async Task RequestBluetooth()
        {
            if (DeviceInfo.Platform != DevicePlatform.Android)
                return;

            var status = await CheckBleStatusAsync();
            if (status == PermissionStatus.Granted)
            {
                await Shell.Current.DisplayAlert(Constants.Constants.grantedPermissionTitle, Constants.Constants.scanDevices, Constants.Constants.ok);
                return;

            }
               

            if (DeviceInfo.Version.Major >= 12)
            {


                if (Permissions.ShouldShowRationale<BleConnectPermission>())
                {
                    await Shell.Current.DisplayAlert(Constants.Constants.needsPermission, Constants.Constants.scanBle, Constants.Constants.ok);
                }

                status = await Permissions.RequestAsync<BleConnectPermission>();


            }
            else
            {

                if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>())
                {
                    await Shell.Current.DisplayAlert(Constants.Constants.needsPermission, Constants.Constants.scanBle, Constants.Constants.ok);
                }

                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();


            }


            if (status != PermissionStatus.Granted)
            {
                await Shell.Current.DisplayAlert(Constants.Constants.permissionRequired,
                   Constants.Constants.locationPermission, Constants.Constants.ok);
            }
               
        }

        /// <summary>
        /// Connect to the device tapped. 
        /// </summary>
        /// <param name="device"></param>

        [RelayCommand]
        public async void ConnectToDevice(string device)
        {
            try
            {
                if (Items.Count == 0)
                {
                    // if we land here with no items something went wrong
                    await Shell.Current.DisplayAlert(Constants.Constants.unableToConnectTitle, Constants.Constants.connectedTo, Constants.Constants.ok);
                    return;

                }
                Status = Constants.Constants.notConnected;

                var result = _bleClientService.Connect(device);
                Console.WriteLine("DEBUG bleListview_ItemTapped Connect | " + result);
                if (result == false)
                {
                    bool x = await Application.Current.MainPage.DisplayAlert(Constants.Constants.unableToConnectTitle, Constants.Constants.somethingWentWrong, Constants.Constants.ok, Constants.Constants.cancel);
                }
                else
                {
                    await Shell.Current.DisplayAlert(Constants.Constants.connectionSuccessTitle, Constants.Constants.youAreNowConnected + device+ Constants.Constants.vscode, Constants.Constants.ok, Constants.Constants.cancel);
                    Status = Constants.Constants.connected;
                }


            }
            catch
            {
                await Shell.Current.DisplayAlert(Constants.Constants.unableToConnectTitle, Constants.Constants.connectedTo, Constants.Constants.cancel);
            }
            finally
            {
                IsBusy = false;

            }

        }

        /// <summary>
        /// Start the scanning of Ble devices.
        /// </summary>

        [RelayCommand]
        public async void ScanBtn_Clicked()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;


            try
            {
                var status = await CheckBleStatusAsync();

                if (status == PermissionStatus.Denied)
                {
                    await Application.Current.MainPage.DisplayAlert(Constants.Constants.unableToScanTitle, Constants.Constants.pleaseMakeSureBle, Constants.Constants.cancel);
                    return;
                }

                _bleClientService = Resolver.Resolve<IBluetoothClient>();
                var result = _bleClientService.StartScan(FoundDevice);
                Console.WriteLine("DEBUG |ScanBtn_Clicked " + result);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(Constants.Constants.unableToScanTitle, Constants.Constants.pleaseMakeSureBle, Constants.Constants.cancel);

            }
            finally
            {
                IsBusy = false;
            }


        }
    }
    #endregion
}

