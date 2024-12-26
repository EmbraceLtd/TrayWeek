﻿using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Text;
using System.Windows;

namespace TrayWeek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Draw();
        }

        public void Draw()
        {
            var greg = new GregorianCalendar();
            string inputString = greg.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday).ToString();

            MyNotifyIcon.ToolTipText= $"Week {inputString}";
            MyNotifyIcon.Icon = StringToIcon(inputString);
        }

        public Icon StringToIcon(string input)
        {
            // Pen color depending on dark or light theme
            Brush brush = GetTheme() == WindowsTheme.Dark ? new SolidBrush(Color.White) : new SolidBrush(Color.Black);
            Bitmap bitmap;

            if (Environment.OSVersion.Version.Build >= 22000)
            {
                // Win 11
                Font font = new Font("Arial Narrow", 22, System.Drawing.FontStyle.Regular);
                bitmap = new Bitmap(32, 32);
                bitmap.MakeTransparent(Color.White);
                Graphics graphics = Graphics.FromImage(bitmap);
                var stringSize = graphics.MeasureString(input, font, 256);
                graphics.DrawString(input, font, brush, 16 - stringSize.Width / 2, 16 - stringSize.Height / 2);
            }
            else
            {
                // Win 10
                Font font = new Font("Arial", 10, System.Drawing.FontStyle.Regular);
                bitmap = new Bitmap(16, 16);
                bitmap.MakeTransparent(Color.White);
                Graphics graphics = Graphics.FromImage(bitmap);
                var stringSize = graphics.MeasureString(input, font, 24);
                graphics.DrawString(input, font, brush, 8 - stringSize.Width / 2, 8 - stringSize.Height / 2);
            }

            var iconHandle = bitmap.GetHicon();
            var icon = System.Drawing.Icon.FromHandle(iconHandle);

            return icon;
        }

        private void ContextMenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private enum WindowsTheme
        {
            Dark,
            Light
        }

        private static WindowsTheme GetTheme()
        {
            var taskBarColour = Taskbar.GetColourAt(Taskbar.GetTaskbarPosition().Location);
            if (taskBarColour.Name == "ffb7bec4")
                return WindowsTheme.Light;
            else
                return WindowsTheme.Dark;
        }
    }
}