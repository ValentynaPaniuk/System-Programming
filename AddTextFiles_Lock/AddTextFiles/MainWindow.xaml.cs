using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AddTextFiles
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         Написати програму для об'єднання файлів у обраному каталозі
         Елементи керування: Кнопка, яка дозволяє обрати шлях до каталогу
         Лейбл - на якому вказується обраний шлях
         Кнопка для старту об'єднання
         Прогрес-бар - відображає "хід виконанння"
         
         Вимоги:
         відкривання файлів та зчитування даних, а також дописування до результуючого файлу реалізувати за допомогою
         синхронізації потоків. Результуючий файл має зберігатися в каталозі Debug/Test/result.txt
         Вміст - це сумарний вміст файлів, що містяться у каталозі, до якого юзер обрав шлях
         Запис та зчитування організувати за допомогою потоків
         Передбачити аварійне закриття програми, та обробити всі можливі виключні ситуації
          */

        ObservableCollection<string> files = new ObservableCollection<string>();
        StringBuilder sb = new StringBuilder();
        public string Path { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            lbContext.ItemsSource = files;
        }

        private void BtnDialog_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                Path = folderBrowser.SelectedPath.ToString();

            foreach (var file in Directory.EnumerateFiles(Path, "*.*")
                                          .Where(s => s.EndsWith(".txt") || s.EndsWith(".cs")))
                files.Add(file.ToString());

            lbPath.Content = Path;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Thread threadForRead = new Thread(Read);
            threadForRead.Start();
            Thread threadForWrite = new Thread(Write);
            threadForWrite.Start();
            Thread threadForLoad = new Thread(Load);
            threadForLoad.Start();
        }

        private void Load()
        {
            lock (this)
            {
                int lengs = 0;
                foreach (var item in files)
                    lengs += item.Length;

                Dispatcher.Invoke(() => pbLoad.Maximum = lengs);
                for (int i = 0; i < lengs; i++)
                    Dispatcher.Invoke(() => pbLoad.Value++);

                Dispatcher.Invoke(() => tbComlite.Text = "Complete");
            }
        }

        private void Read()
        {
            lock (this)
                for (int i = 0; i < files.Count; i++)
                    using (FileStream fs = File.OpenRead(files[i]))
                    {
                        byte[] array = new byte[fs.Length];
                        fs.Read(array, 0, array.Length);
                        sb.Append(Encoding.Default.GetString(array));
                    }
        }
        private void Write()
        {
            lock (this)
                using (FileStream fstream = new FileStream($"{Directory.GetCurrentDirectory()}\\Test/result.txt", FileMode.OpenOrCreate))
                {
                    byte[] array = Encoding.Default.GetBytes(sb.ToString());
                    fstream.Write(array, 0, array.Length);
                }
        }


    }
}
