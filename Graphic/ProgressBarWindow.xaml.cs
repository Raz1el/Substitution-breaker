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
using Substitution_breaker;

namespace Graphic
{
    /// <summary>
    /// Interaction logic for ProgressBar.xaml
    /// </summary>
    public partial class ProgressBarWindow : Window
    {
        public ProgressBarWindow(int maximumIterCount)
        {
            
            InitializeComponent();
            progressBar.Maximum = maximumIterCount;
        }

        public void ProgressChanged(object sender,State state)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                progressBar.Value = state.Progress;
            });
         
        }
    }
}
