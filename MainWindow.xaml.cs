﻿using System.Drawing;
using System.Globalization;
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
            string inputString = GetIso8601WeekOfYear(DateTime.Now.Date).ToString();

            MyNotifyIcon.ToolTipText = $"Week {inputString}";
            MyNotifyIcon.Icon = StringToIcon(inputString);
        }

        public Icon StringToIcon(string input)
        {
            var fgColor = Color.Black;
            var bgColor = Color.White;

            var bitmapSize = 16;
            var fontSize = 8;

            var font = new Font("Segoe UI", fontSize, System.Drawing.FontStyle.Regular);
            var bitmap = new Bitmap(bitmapSize, bitmapSize);
            var extraOffset = (new[] { "10", "12", "13", "14", "15", "16", "17", "18", "19" }).Contains(input) ? -1 : 0;

            var graphics = Graphics.FromImage(bitmap);
            var stringSize = graphics.MeasureString(input, font, 256);

            graphics.FillRectangle(new SolidBrush(bgColor), 0, 0, bitmapSize - 1, bitmapSize - 1);
            graphics.DrawRectangle(new Pen(fgColor), 0, 0, bitmapSize - 1, bitmapSize - 1);
            graphics.DrawString(input, font, new SolidBrush(fgColor), bitmapSize / 2 - stringSize.Width / 2 + extraOffset, bitmapSize / 2 - stringSize.Height / 2 + 1);

            return System.Drawing.Icon.FromHandle(bitmap.GetHicon());
        }

        private void ContextMenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ContextMenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TrayWeek 1.0\r\n\r\n© Tommy Sjöblom 2025\r\n\r\nhttps://github.com/EmbraceLtd/TrayWeek", "About", MessageBoxButton.OK, MessageBoxImage.None, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }

        public static int GetIso8601WeekOfYear(DateTime date)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
                date = date.AddDays(3);

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}