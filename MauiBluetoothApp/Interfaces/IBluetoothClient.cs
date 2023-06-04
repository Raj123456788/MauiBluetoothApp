using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBluetoothApp.Interfaces
{
    /// <summary>
    /// Interface for the Bluetooth Client.
    /// </summary>
    public partial interface IBluetoothClient

    {
        bool? IsEnable { get; }
        bool? StartScan(Action<string, string> foundDevice);

        bool? Connect(string device);

    }
}
