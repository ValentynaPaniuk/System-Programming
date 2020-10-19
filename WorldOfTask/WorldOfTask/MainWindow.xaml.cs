using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using TankLib;

namespace WorldOfTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Tank> tanksRed;
        ObservableCollection<Tank> tanksBlue;
        public MainWindow()
        { 
          InitializeComponent();

            tanksRed = new ObservableCollection<Tank>() 
            { 
            new Tank("T-32"),
            new Tank("T-32"),
            new Tank("T-32"),
            new Tank("T-32"),
            new Tank("T-32")
            };
            tanksBlue = new ObservableCollection<Tank>()
            {
            new Tank("Pantera"),
            new Tank("Pantera"),
            new Tank("Pantera"),
            new Tank("Pantera"),
            new Tank("Pantera")
            };
            lbredTanks.ItemsSource = tanksRed;
            lbblueTanks.ItemsSource = tanksBlue;
        }

        private void btnFight_Click(object sender, RoutedEventArgs e)
        {
            int coutRed = 0;
            int coutBlue = 0;

            for (int i = 0; i < 5; i++)
            {
                Tank win = tanksBlue[i] ^ tanksRed[i];
                if (win.Name == "T-32")
                    coutRed++;
                else
                    coutBlue++;
            }
            lRed.Content = coutRed;
            lBlue.Content = coutBlue;

            if (coutRed > coutBlue)
                MessageBox.Show("T-32 team - Win");
            else
                MessageBox.Show("Pantera team - Win");
        }
    }
}
