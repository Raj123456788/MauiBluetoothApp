using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBluetoothApp.Interfaces
{
    public partial interface IBleClient
    {
        bool? IsEnable { get; }
        bool ScanForDevices(Action<string, string> foundDevice);

        bool ConnectToDevice(string device);
    }
}
