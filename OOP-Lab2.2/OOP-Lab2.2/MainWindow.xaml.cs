using System;
using System.Windows;
using System.Globalization;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxX.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double x) &&
                double.TryParse(TextBoxY.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double y) &&
                double.TryParse(TextBoxZ.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double z))
            {
                try
                {
                    double numerator = 2 * Math.Cos(Math.Pow(x, 2)) - 1 / Math.Sqrt(2) + Math.Exp(2);

                    double denominator = 2.0 / 3.0 + Math.Sin(Math.Pow(y, 2) - z);

                    if (denominator == 0)
                    {
                        ResultTextBlock.Text = "Помилка: знаменник не може дорівнювати нулю.";
                    }
                    else
                    {
                        double s = numerator / denominator;
                        double roundedS = Math.Round(s, 3);
                        ResultTextBlock.Text = $"Результат: s = {roundedS}";
                    }
                }
                catch (Exception ex)
                {
                    ResultTextBlock.Text = $"Помилка: {ex.Message}";
                }
            }
            else
            {
                ResultTextBlock.Text = "Некоректне введення. Будь ласка, введіть дійсні числа.";
            }
        }
    }
}
