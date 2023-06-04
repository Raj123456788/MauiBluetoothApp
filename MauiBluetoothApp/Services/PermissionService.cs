using MauiBluetoothApp.Interfaces;
using System.Security;

namespace MauiBluetoothApp.Services;

internal partial class PermissionService: IPermissionBluetooth
{
    public Task<PermissionStatus> CheckBluetooth()
    {
        Task<PermissionStatus> result = null;
        CheckBluetoothHandler(ref result);
        if (result != null)
            return result;
        else
            return result = Task.FromResult(PermissionStatus.Unknown);
    }

    partial void CheckBluetoothHandler(ref Task<PermissionStatus> task);
}
