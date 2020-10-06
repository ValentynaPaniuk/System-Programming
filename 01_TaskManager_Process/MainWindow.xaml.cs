using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _11_TaskManager_Process
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Process> processes { get; set; } = new ObservableCollection<Process>();
       

        public MainWindow()
        {
            InitializeComponent();
            lb.ItemsSource = processes;

            foreach (var item in Process.GetProcesses())
            {
                try
                {
                    processes.Add(item);
                    
                }
                catch { }
            }
           

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            Process proc = new Process();
            startInfo.FileName = tb.Text + ".exe";
            startInfo.WindowStyle = ProcessWindowStyle.Normal;


            proc.StartInfo = startInfo;
            processes.Add(proc);

            proc.Start();

           

        }

      

        private void Kill_Click(object sender, RoutedEventArgs e)
        {
            string processName;
            try
            {
                processName = lb.SelectedItem.ToString();
                               
            }
            catch
            {
                MessageBox.Show("Don't select process");
                return;
            }

            foreach (var item in processes)
            {
                
                if (processName == item.ToString())
                {
                    item.Kill();
                }
            }

            processes.Clear();
            foreach (var item in Process.GetProcesses())
            {
                try
                {
                    processes.Add(item);

                }
                catch { }
            }


        }
    

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            processes.Clear();
            foreach (var item in Process.GetProcesses())
            {
                try
                {
                    processes.Add(item);

                }
                catch { }
            }

        }
    }
}
