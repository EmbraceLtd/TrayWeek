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
            string inputString = greg.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek,DayOfWeek.Monday).ToString();

            MyNotifyIcon.Icon = StringToIcon(inputString);
            MyNotifyIcon.ToolTipText = $"Week {inputString}";
        }

        public Icon StringToIcon(string input)
        {
            Font font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
            Brush brush = new SolidBrush(Color.White);

            Bitmap bitmap = new Bitmap(16, 16);
            bitmap.MakeTransparent(Color.Black);
            Graphics graphics = Graphics.FromImage(bitmap);
            var stringSize = graphics.MeasureString(input, font, 24);

            //graphics.Clear(Color.Black);
            graphics.DrawString(input, font, brush, 8-stringSize.Width/2, 8-stringSize.Height/2);

            var iconHandle = bitmap.GetHicon();
            var icon = System.Drawing.Icon.FromHandle(iconHandle);

            return icon;
        }

        private void ContextMenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}