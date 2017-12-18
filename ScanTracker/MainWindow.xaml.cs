using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;

namespace ScanTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private DataProvider d = new DataProvider();
        private string title = "Отслеживание сервера опроса ";
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(refreshRate.Value);
            timer.Tick += Timer_Tick;
            timer.Start();
            Timer_Tick(this, new EventArgs());
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Process[] procs = Process.GetProcesses();
            this.Title = title + procs.Count(p => p.ProcessName.ToLower() == "pso");
            try
            {
                lstUSPD.ItemsSource = d.ActiveUSPD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
                this.Close();
            }
        }

        private void refreshRate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            timer.Interval = TimeSpan.FromSeconds(refreshRate.Value);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;
        }
    }
}
