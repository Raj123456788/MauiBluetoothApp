using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content;
using Java.Util;
using MauiBluetoothApp.Core;
using MauiBluetoothApp.Interfaces;
using Timer = System.Threading.Timer;

namespace MauiBluetoothApp.Models;

internal sealed class BleClient : IBleClient
{
    private BluetoothManager mCentralManager;
    private IScanCallback mScanCallback;
    private readonly IBleCallBack mConnectCallback;

    private Timer _ScanTimer;
    private Timer _ConnectTimer;
    private BluetoothGatt _BluetoothGatt;

    public BleClient()
    {
        // Our App should only have one instance of callback hence ScanCallback & BleCallBack classes are sealed.
        mScanCallback = Resolver.Resolve<IScanCallback>();
        mConnectCallback = Resolver.Resolve<IBleCallBack>();
    }
    /// <summary>
    /// Check if BluetoothAdapter is enabled so that it can conduct overall Bluetooth Management.
    /// </summary>

    public bool? IsEnable
    {
        get
        {
            try
            {
                return ((BluetoothManager)Android.App.Application.Context.GetSystemService(Context.BluetoothService)).Adapter.IsEnabled;
            }
            catch
            {
                return false;
            }
        }
    }
    /// <summary>
    /// Scans the near by BLE devices.
    /// Bluetooth MAnager which was formally called Bluetoothadapter.
    /// </summary>
    /// <param name="foundDevice">This the call back and will be called everytime a new device is discovered.</param>
    /// <returns></returns>
    public bool ScanForDevices(Action<string, string> foundDevice)
    {
        if (mCentralManager == null)
            mCentralManager = (BluetoothManager)Android.App.Application.Context.GetSystemService(Android.App.Application.BluetoothService);

        mScanCallback.FoundDevice -= foundDevice;
        mScanCallback.FoundDevice += foundDevice;

        mScanCallback.Devices = new List<BluetoothDevice>();

        _ScanTimer = new Timer((obj) =>
        {
            mCentralManager.Adapter.BluetoothLeScanner.StopScan((ScanCallback)mScanCallback);
        }, null, 1000000, Timeout.Infinite);

        // We can change scan mode to Balanced as well but with lowlatency is recommended for applications running in foreground.
        var settings = new ScanSettings.Builder().SetScanMode(Android.Bluetooth.LE.ScanMode.LowLatency).Build();
        mCentralManager.Adapter.BluetoothLeScanner.StartScan(null, settings, (ScanCallback)mScanCallback);

        return false;
    }
    /// <summary>
    /// Connects to the Device.
    /// </summary>
    /// <param name="device"></param>
    /// <returns></returns>

    public bool ConnectToDevice(string device)
    {
        var bleDevice = mScanCallback.Devices?.FirstOrDefault(d => d.Name == device);
        if (bleDevice != null)
        {
            _ConnectTimer = new Timer((obj) =>
            {
                _BluetoothGatt?.Disconnect();
                _BluetoothGatt?.Dispose();
            }, null, 10000, Timeout.Infinite);


            _BluetoothGatt = bleDevice.ConnectGatt(
                Android.App.Application.Context,
                false,
                (BluetoothGattCallback)mConnectCallback
               );
            Console.WriteLine("DEBUG GATT| " + _BluetoothGatt.Device);

            return true;
        }

        return false;
    }
}
