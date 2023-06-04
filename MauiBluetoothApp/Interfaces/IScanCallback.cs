using Android.Bluetooth;
using Android.Bluetooth.LE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBluetoothApp.Interfaces
{
    internal interface IScanCallback
    {
        Action<string, string> FoundDevice { get; set; }
        List<BluetoothDevice> Devices { get; set; }
        void OnScanResult(ScanCallbackType callbackType, ScanResult result);
    }
}
