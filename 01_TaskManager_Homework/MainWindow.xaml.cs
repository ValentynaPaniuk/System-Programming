using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

namespace _01_TaskManager_Homework
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        /*
        Коли натискаємо Старт - програма запускається і зникає з переліку доступних, і з'являється в переліку запущених.
        Коли зупиняємо - навпаки.

     */
    {
        ObservableCollection<string> Files { get; set; } = new ObservableCollection<string>();
        ObservableCollection<string> OpenedProcesses { get; set; } = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();

            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            foreach (var item in dir.GetFiles())
            {
                if (item.Extension.Equals(".exe"))
                    Files.Add(System.IO.Path.GetFileName(item.Name));
            }
            lbAccess.ItemsSource = Files;
            lbOpened.ItemsSource = OpenedProcesses;
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start($"{tbProcessName.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            OpenedProcesses.Add(tbProcessName.Text.TrimEnd(new char[] { '.', 'e', 'x', 'e' }));
            Files.Remove(tbProcessName.Text);

        }

        private void lbAccess_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (sender as ListBox);
            if (lb.SelectedIndex == -1)
                return;
            tbProcessName.Text = lb.SelectedItem.ToString();
        }

        private void KillBtn_Click(object sender, RoutedEventArgs e)
        {

            foreach (var item in Process.GetProcesses())
            {
                if (item.ProcessName == tbProcessName.Text)
                {
                    item.Kill();
                    OpenedProcesses.Remove(item.ProcessName);
                    Files.Add(item.ProcessName + ".exe");
                }
            }
        }
    }
}

