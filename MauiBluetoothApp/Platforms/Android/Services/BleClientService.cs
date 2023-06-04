using MauiBluetoothApp.Core;
using MauiBluetoothApp.Interfaces;

namespace MauiBluetoothApp.Services;

/// <summary>
/// Platform specific BLE client service will let you perform bluetooth functionalities like BLE scan and connect.
/// </summary>

internal partial class BleClientService
{
    private IBleClient mBleClient;

    public BleClientService()
    {
        mBleClient = Resolver.Resolve<IBleClient>();

    }
    #region Handlers for BLE

    partial void IsEnableHandler(ref bool? enable)
    {
        enable = mBleClient.IsEnable;
    }

    partial void ScanHandler(Action<string, string> foundDevice, ref bool? result)
    {
        result = mBleClient.ScanForDevices(foundDevice);
    }

    partial void ConnectHandler(string device, ref bool? result)
    {
        result = mBleClient.ConnectToDevice(device);
    }
    #endregion
}
