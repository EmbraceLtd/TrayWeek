using Microsoft.Win32;
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
            string inputString = GetIso8601WeekOfYear(DateTime.Now.Date).ToString();

            MyNotifyIcon.ToolTipText = $"Week {inputString}"; 
            MyNotifyIcon.Icon = StringToIcon(inputString);
        }

        public Icon StringToIcon(string input)
        {
            var fgColor = Color.Black;
            var bgColor = Color.White;

            Bitmap bitmap;
            var bitmapSize = 16;
            var fontSize = 8;

            Font font = new Font("Segoe UI", fontSize, System.Drawing.FontStyle.Regular);
            bitmap = new Bitmap(bitmapSize, bitmapSize);
            Graphics graphics = Graphics.FromImage(bitmap);
            var stringSize = graphics.MeasureString(input, font, 256);
            graphics.FillRectangle(new SolidBrush(bgColor), 0, 0, bitmapSize - 1, bitmapSize - 1);
            graphics.DrawRectangle(new Pen(fgColor), 0, 0, bitmapSize - 1, bitmapSize - 1);
            graphics.DrawString(input, font, new SolidBrush(fgColor), bitmapSize / 2 - stringSize.Width / 2, bitmapSize / 2 - stringSize.Height / 2 + 1);

            var iconHandle = bitmap.GetHicon();
            var icon = System.Drawing.Icon.FromHandle(iconHandle);

            return icon;
        }

        private void ContextMenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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