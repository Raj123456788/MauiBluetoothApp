using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBluetoothApp.Interfaces
{
    public partial interface IPermissionBluetooth
    {
        Task<PermissionStatus> CheckBluetooth();
        partial void CheckBluetoothHandler(ref Task<PermissionStatus> task);
    }
}
