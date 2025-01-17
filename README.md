TrayWeek
========

Description
-----------

Displays the current week number in the windows tray, according to ISO 8601 (Swedish standard).

ISO 8601 states that the first week of the year is the week that contains the first Thursday of the year. 

Furthermore, weeks do not change number in the middle of the week if New Year occurs during the week.

Tech
----

Implemented as a windowless WPF application for .NET 8 (runtime required).  
NuGet dependencies: [Hardcodet.NotifyIcon.Wpf](https://github.com/hardcodet/wpf-notifyicon)

Users must themselves choose to permanently show the tray icon in the system settings!

A setup project is included that produces a msi file when built.
