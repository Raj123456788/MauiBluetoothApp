using MauiBluetoothApp.Interfaces;

namespace MauiBluetoothApp.Services;
/// <summary>
/// This service enables to start, connect & stop the BLE discovery.
/// It will call the platfor specific handler to perform the operation.
/// </summary>

internal partial class BleClientService: IBluetoothClient
{
    public bool? IsEnable
    {
        get
        {
            bool? enable = null;
            IsEnableHandler(ref enable);
            return enable;
        }
    }

    public bool? StartScan(Action<string,string> foundDevice)
    {
        if (IsEnable == true)
        {
            bool? result = null;
            ScanHandler(foundDevice, ref result);
            return result;
        }
        return null;
    }

    public bool? Connect(string device)
    {
        if (IsEnable == true)
        {
            bool? result = null;
            ConnectHandler(device, ref result);
            return result;
        }
        return null;
    }

    partial void IsEnableHandler(ref bool? enable);
    partial void ScanHandler(Action<string,string> foundDevice, ref bool? result);
    partial void ConnectHandler(string device, ref bool? result);
}
