using Android.Bluetooth;
using Android.Runtime;
using Android.Util;
using Java.Lang;
using Java.Util;
using MauiBluetoothApp.Interfaces;

namespace MauiBluetoothApp.Models;

internal sealed class BleConnectCallback : BluetoothGattCallback,IBleCallBack

{
    // BluetoothGattCharacteristic _characteristicread;
    public override void OnConnectionStateChange(BluetoothGatt gatt, [GeneratedEnum] GattStatus status, [GeneratedEnum] ProfileState newState)
    {
        Console.WriteLine($"DEBUG On Connection Changed | device={gatt?.Device?.Name} status={status} newState={newState}");
        // Tried with different UUID but was unable read or write the characteristics.

        // string uuid = "7a8c06ad-c009-4da9-96bb-6d905d2db930";


        // BluetoothGattService service = gatt.GetService(UUID.FromString(uuid));
        // //gatt.GetService()
        // BluetoothGattCharacteristic characterstic =service.GetCharacteristic(UUID.FromString("5caaabea-17ad-4a94-abcf-5b835cbcadff"));
        // byte []command = new byte[20];
        // command[0] = 42;
        // command[1] = 41;
        // command[2] = 54;
        // command[3] = 54;
        // command[4] = 45;
        // command[5] = 52;
        // command[6] = 59;

        // for (int i = 7; i < 20; i++)
        //     command[i] = 0x00;

        // characterstic.SetValue(command);

        // try
        // {
        //     System.Threading.Thread.Sleep(500);
        // }
        // catch (InterruptedException var9)
        // {

        // }

        //bool writeStatus= gatt.WriteCharacteristic(characterstic);
        //setRecieverNotify(mGattService);
        //setCharacteristicNotification(characterstic, true);
        ////mtransmitData = new TransmitData();
        //BluetoothGattCharacteristic characteristic = service.GetCharacteristic(CHARACTERISTIC_UUID);

        //BluetoothGattDescriptor descriptor = characteristic.GetDescriptor(DESCRIPTOR_UUID);
        //descriptor.SetValue((byte[])BluetoothGattDescriptor.EnableNotificationValue);
        //characteristic.AddDescriptor(descriptor);
        //characteristic.SetValue(BluetoothGattCharacteristic.WriteTypeNoResponse);
        //gatt.WriteDescriptor(descriptor);

        //gatt.SetCharacteristicNotification(characteristic, true);

    }

    //async private void startRecieve()
    //{
    //    _characteristicread = await _service.GetCharacteristicAsync(Guid.Parse(_bleconInfo.UUCharacteristic));
    //    if (_characteristicread.CanRead == true)
    //    {
    //        Debug.WriteLine("受信可能になった");
    //        _characteristicread.ValueUpdated += Characteristicread_ValueUpdated;    //ValueUpdateイベント登録
    //        await _characteristicread.StartUpdatesAsync();
    //        //characteristicread.ValueUpdated += (o, args) =>
    //        //{
    //        //	var bytes = args.Characteristic.Value;
    //        //};
    //        //await characteristicread.StartUpdatesAsync();
    //    }
    //    return;

    //    //while (true)
    //    //{
    //    //	if(_rec == true)
    //    //	{
    //    //		_rec = false;
    //    //		Read();
    //    //	}
    //    //	Task.Delay(100).Wait();
    //    //}
    //    //_tim = new System.Timers.Timer();
    //    //_tim.Interval = 100;
    //    //_tim.Elapsed += _tim_Elapsed;
    //    //_tim.Start();

    //}

    public override void OnCharacteristicRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, [GeneratedEnum] GattStatus status)
    {
        base.OnCharacteristicRead(gatt, characteristic, status);
        Console.WriteLine("Char read");
    }
    public override void OnCharacteristicChanged(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic)
    {
        base.OnCharacteristicChanged(gatt, characteristic);
        Console.WriteLine("Char changed");
    }

    public override void OnCharacteristicWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, [GeneratedEnum] GattStatus status)
    {
        base.OnCharacteristicWrite(gatt, characteristic, status);
        Console.WriteLine("Char write");
    }
}
