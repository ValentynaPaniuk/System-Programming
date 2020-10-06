using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFilesWF
{
    public partial class Form : System.Windows.Forms.Form
    {
        /*
          Написати програму для копіювання каталога та всіх вкладених папок/файлів 
           Інтерфейс: 
           - кнопка "Джерело" - при настиненні відкриваємо FolderBrowerDialog та обираємо каталог
           - кнопка "Призначення" - аналогічно обираємо куди будемо перекопійовувати файли
           - кнопка "Пуск" - по натисненні розпочинається процес копіювання всього вмісту каталога "Джерело" у "Призначення"
           Вимоги:
           під час копіювання програма не має блокуватись, а лишатись "робочою"
           хід виконання продумати таким, щоб користувач РОЗУМІВ, що процес відбувається (наприклад, прогресбар, таймер)
         */
        public Form()
        {
            InitializeComponent();

        }

        private void BPathFrom_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                lFrom.Text = folderBrowserDialog1.SelectedPath;
            }

             Thread t1 = new Thread(AddPathFrom);
            t1.Start(lFrom.Text);

            //AddPathFrom();

        }

        private void AddPathFrom(object state)
        {
            listBox1.Invoke((Action)delegate() {
                listBox1.Items.Clear();
             
                               
                    string[] files = Directory.GetFiles(state.ToString(), "*.*", SearchOption.AllDirectories);
                    string[] arrays = { };



                    foreach (var item in files)
                    {
                        arrays = Directory.GetFiles(state.ToString(), "*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x)).ToArray();
                        Console.WriteLine(arrays);

                    }

                    listBox1.Items.AddRange(arrays);

                
            });
           
        }

        private void BTo_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog2.SelectedPath))
            {
                lTo.Text = folderBrowserDialog2.SelectedPath;
            }

            Thread t2 = new Thread(AddPathTo);
            t2.Start(lTo.Text);
            //AddPathTo();


           
        }

        private void AddPathTo(object state)
        {
            listBox2.Invoke((Action)delegate ()
            {

                listBox2.Items.Clear();

                lTo.Text = folderBrowserDialog2.SelectedPath;



                string[] files = Directory.GetFiles(state.ToString(), "*.*", SearchOption.AllDirectories);

                string[] arrays = { };



                foreach (var item in files)
                {
                    arrays = Directory.GetFiles(state.ToString(), "*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x)).ToArray();


                }

                listBox2.Items.AddRange(arrays);

            });
        }


        private void BCopy_Click(object sender, EventArgs e)
        {
            
            Thread t3 = new Thread(new ParameterizedThreadStart(CopyFiles));
            t3.Start();
           


            //CopyFiles();
            //TimerProcess();

        }

       

      

        private void CopyFiles(object catalogs)
        {


            string sourceDir = folderBrowserDialog1.SelectedPath;
            string backupDir = folderBrowserDialog2.SelectedPath;

            try
            {

                string[] txtList = Directory.GetFiles(sourceDir, "*.*");


                // Copy text files.
                foreach (string f in txtList)
                {

                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);

                    try
                    {
                        // Will not overwrite if the destination file already exists.
                        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName));

                        string[] files = Directory.GetFiles(folderBrowserDialog2.SelectedPath, "*.*", SearchOption.AllDirectories);


                        string[] arrays = { };



                        foreach (var item in files)
                        {
                            arrays = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*", SearchOption.AllDirectories).Select(x => Path.GetFileName(x)).ToArray();

                        }


                        listBox2.Items.AddRange(arrays);
                    }

                    // Catch exception if the file was already copied.
                    catch (IOException copyError)
                    {
                        Console.WriteLine(copyError.Message);
                    }
                }

                // Delete source files that were copied.
                //foreach (string f in txtList)
                //{
                //    File.Delete(f);
                //}

                timer1.Interval = 100;
                timer1.Enabled = true;
                timer1.Tick += Timer1_Tick;

            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }






        }

        void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

       
    }
}
