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
using System.ComponentModel;
using System.Threading;

namespace Zcord
{
    /// <summary>
    /// Interaction logic for Splash_Screen.xaml
    /// </summary>
    public partial class Splash_Screen : Window
    {
        public Splash_Screen()
        {
            InitializeComponent();
        }

        // Creates a background worker instance to handle the bg work
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_Dowork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        // Increments the progress value of the progress bar
        void worker_Dowork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(80);
            }

        }

        // Monitors value of the progress bar. If it's 100 then the next window will be shown
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            
            if(progressBar.Value == 100)
            {
                MainWindow mainwindow = new MainWindow();
                Close();
                mainwindow.ShowDialog();
            }
        }
    }
}
