using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Graphic
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private MainWindow _window;
        private string sample;
        public SettingsWindow()
        {
            InitializeComponent();
        }

        public SettingsWindow(MainWindow window):this()
        {
            _window = window;
        }

        private void ExecuteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var attempts = int.Parse(NumberOfAttemptsTextBox.Text);
            if (attempts != _window.Attempts)
            {
                _window.Attempts = attempts;
            }
            this.Close();
        }
    }
}
