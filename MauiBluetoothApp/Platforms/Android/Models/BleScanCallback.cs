using Android.Bluetooth;
using Android.Bluetooth.LE;
using MauiBluetoothApp.Interfaces;

namespace MauiBluetoothApp.Models;
/// <summary>
/// Scan results are reported using this class.
/// </summary>

internal sealed class BleScanCallback : ScanCallback, IScanCallback
{
    public Action<string, string> FoundDevice { get; set; }

    // Maintains the list of discovered devices.
    public List<BluetoothDevice> Devices { get; set; }

    /// <summary>
    /// This class provides the scanned devices info. It can provide more information than Name & adderess including the RSSI & Txpower.
    /// </summary>
    /// <param name="callbackType"></param>
    /// <param name="result"></param>
    public override void OnScanResult(ScanCallbackType callbackType, ScanResult result)
    {
        if (Devices != null)
            if (result?.Device?.Name != null)
                if (!Devices.Any(d => d.Name == result?.Device?.Name))
                {
                    FoundDevice?.Invoke(result?.Device?.Name, result?.Device?.Address);
                    Devices.Add(result.Device);
                }
    }
}
