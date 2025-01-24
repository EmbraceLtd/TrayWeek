![w6jeFJ2hMb](https://github.com/user-attachments/assets/87db362c-4b45-4a0f-81f9-787ae8bd46e9)

TrayWeek
========

Description
-----------

Displays the current week number in the windows tray, according to ISO 8601 (Swedish standard).

ISO 8601 states that 

* Weeks start on a Monday and end on a Sunday.
* The first week of the year is the week that contains the first Thursday of the year. 
* Week 1 is called week 1 throughout the whole week.

Example: Week 1 of 2025 starts on Monday 30 Dec, 2024 and is called week 1 during the whole week, which lasts until Sunday Jan 5, 2025.


Tech
----

Implemented as a windowless WPF application for .NET 8 ([runtime required](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)).  
NuGet dependencies: [Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon)

Users must themselves choose to permanently show the tray icon in the system settings!
