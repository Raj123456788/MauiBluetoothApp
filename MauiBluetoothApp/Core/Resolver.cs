using MauiBluetoothApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MauiBluetoothApp.Services;
using Autofac;
using AutofacIContainer = Autofac.IContainer;
using MauiBluetoothApp.Models;

namespace MauiBluetoothApp.Core
{
    internal class Resolver
    {
        private static AutofacIContainer _container;

        public static void Build()
        {
            ContainerBuilder builder = new();

            builder.RegisterType<PermissionService>().As<IPermissionBluetooth>().SingleInstance();
            builder.RegisterType<BleClientService>().As<IBluetoothClient>().SingleInstance();
            builder.RegisterType<BleClient>().As<IBleClient>().SingleInstance();
            builder.RegisterType<BleScanCallback>().As<IScanCallback>().SingleInstance();
            builder.RegisterType<BleConnectCallback>().As<IBleCallBack>().SingleInstance();

            _container = builder.Build();
        }
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
