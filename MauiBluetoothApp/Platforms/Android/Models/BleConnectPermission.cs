using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MauiBluetoothApp.Models;
/// <summary>
/// Custom permission for the bluetooth.
/// Helper Class that will let you decide different permissions to use in this case it is Bluetooth.
/// I could have kept this outside the platform specific but I did not wanted to use platform specifiers(if Android)
/// </summary>
internal class BleConnectPermission : BasePlatformPermission
{
    public override (string androidPermission, bool isRuntime)[] RequiredPermissions => new List<(string androidPermission, bool isRuntime)>
    {
        (global::Android.Manifest.Permission.BluetoothScan, true),
        (global::Android.Manifest.Permission.BluetoothConnect, true)
    }.ToArray();

}
