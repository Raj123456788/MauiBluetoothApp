namespace MauiBluetoothApp.Services;
/// <summary>
/// Permission class that handles the Android 12: Bluetooth prompt
/// & previous android versions showed location prompt as well.
/// </summary>

internal partial class PermissionService
{
    #region Permission Handler
    partial void CheckBluetoothHandler(ref Task<PermissionStatus> task)
    {
        task = CheckBluetoothHandlerTask();
    }

    private async Task<PermissionStatus> CheckBluetoothHandlerTask()
    {
        PermissionStatus status = PermissionStatus.Unknown;

        if (DeviceInfo.Version < new Version(12, 0))
        {
            status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            await Task.Delay(1000);
        }

        if (DeviceInfo.Version >= new Version(12, 0))
        {
            status = await Permissions.CheckStatusAsync<Models.BleConnectPermission>();
            if (status != PermissionStatus.Granted)
                status = await Permissions.RequestAsync<Models.BleConnectPermission>();
            await Task.Delay(1000);
        }

        return status;
    }
    #endregion
}
