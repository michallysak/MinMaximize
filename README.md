MinMaximize
===========

A Windows shortcut based utility that can be used in mouse/keyboard macros or just keyboard shortcuts.

Configuration
-------------
All you have to had is Windows computer with [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=netcore31 ".NET Core 3.1") installed.

Build and run
-------------
To build type:
```console
dotnet build
```

Create shortcut 
-------------
1. Right-click on built `MinMaximize.exe`
2. Click `Create shortcut`
3. Name shortcut
4. Right-click on `Shortcut.lnk`
5. Click `Properties`
6. In `Target` add console arguments
7. Change `Run` to `Minimized`
8. Set `Shortcut key` (optional)
9. Set `Shortcut.lnk` to mouse/kayboard macros (optional)

Example shortcut configuration:

![Shortcut example](https://github.com/michallysak/MinMaximize/blob/master/shortcut_example.png?raw=true "Shortcut example")

Console arguments
-----------------
Two console options are supported in this order:
1. `app_path` **required**  - path to app
2. `task_name` **optional** -  if is different from `app_path`

`MinMaximize [app_path] [task_name]`

* `MinMaximize notepad`
* `MinMaximize "C:\Users\user_name\app.exe" "AppTaskName" `