# MauiBluetoothApp
Description:  This is a BLE demo android application using Maui, in which you show in a list the devices that are nearby with active Bluetooth connection.
Enviornment: I have used VS community 2022. 
Issues With VS community:
I also had issues with VS code nuget package manager not allowing to install the packages.
Please ignore the bogus VS warnings & errors as seen in the image attached. If info is required please check the output.

Notes: I have used the handler architecture introduced in Maui: We can define one cross-plaform partial class and another partial class with the same name and namespace in each platform folder. This is a pretty clean alternative to using #if directives when working with larger classes/code sections. Performance is also good.
However, a potential disadvantage of this approach is that both partial classes live quite far-away from each other, which could hinder discoverability and increase cognitive load, if there is a lot of shared code.

I have commented in code heavily & Please take a look at the videos attached.

What I would have done if I had more time: I would have definately made a better UI. I also tried reading & writing characteristic(more than connection)

Issues:
I also had issues with VS code nuget package manager not allowing to install the packages.
Please ignore the bogus VS warnings as seen in the image attached.
