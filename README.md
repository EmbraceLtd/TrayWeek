TrayWeek
========

Displays the current week number in the windows tray, according ISO 8601 week numbers.

Implemented as a windowless WPF application for .NET 8 (runtime required).  
NuGet dependencies: [Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon)

Users must themselves choose to permanently show the tray icon in the system settings!

Zip included.

Installation
------------
* Check that you have the .NET 8 desktop runtime installed. https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.11-windows-x64-installer
* Unzip TrayWeek.zip to a folder of your choice.
* Add a shortcut for TrayWeek.exe to %APPDATA%\Microsoft\Windows\Start Menu\Programs\Startup.
* Choose to show the the icon in system tray, like this: https://support.microsoft.com/en-us/windows/customize-the-taskbar-notification-area-e159e8d2-9ac5-b2bd-61c5-bb63c1d437c3
