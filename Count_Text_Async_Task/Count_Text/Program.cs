using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Count_Text
{
    class Program
    {
        /*
         * Задание 1
       Создайте оконное приложение, использующее механизм задач (класс Task). Пользователь вводит в текстовое
       поле некоторый текст. По нажатию на кнопку приложение должно проанализировать текст и вывести отчет. 
        Отчёт содержит информацию о:
       ■ Количестве предложений;
       ■ Количестве символов;
       ■ Количестве слов;
       ■ Количестве вопросительных предложений;
       ■ Количестве восклицательных предложений.
       Отчёт в зависимости от выбора пользователя отображается на экране или сохраняется в файл.
         */
        struct StrAndCounts
        {
            public int Words_Count { get; set; }
            public int Sentence_Count { get; set; }
            public int Question_Count { get; set; }
            public int NotQuestion_Count { get; set; }
            public string Str { get; set; }
        }
        static StrAndCounts str = new StrAndCounts();
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Enter text:");
            str.Str = Console.ReadLine();
            str = await CountsAsync(str);


            Console.WriteLine("What do you whant?\n Show - S or s\n Save int txt - W or w\nExit - E or e");
            Console.Write("-->");
            string res = Console.ReadLine();
            ShowSave(res);

        }

        private static void ShowSave(string res)
        {
           
                if (res == "S" || res == "s")
                    ShowConsole();
                else if (res == "W" || res == "w")
                    WriteFile();
               else
                    Console.WriteLine("Make the right choice!!!");
            
        }

        private static void ShowConsole()
        {
            Console.WriteLine("Words count = " + str.Words_Count);
            Console.WriteLine("Simvols count = " + str.Str.Length);
            Console.WriteLine("Sentenses count = " + str.Sentence_Count);
            Console.WriteLine("Interrogative sentences = " + str.Question_Count);
            Console.WriteLine("Exclamatory sentences = " + str.NotQuestion_Count);
          
        }

        private static void WriteFile()
        {
            string writePath = Directory.GetCurrentDirectory() + "\\textInfo.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, Encoding.Default))
            {
                sw.WriteLine("---------Text info---------");
                sw.WriteLine("Words count = " + str.Words_Count);
                sw.WriteLine("Simvols count = " + str.Str.Length);
                sw.WriteLine("Sentenses count = " + str.Sentence_Count);
                sw.WriteLine("Interrogative sentences = " + str.Question_Count);
                sw.WriteLine("Exclamatory sentences = " + str.NotQuestion_Count);
                sw.WriteLine("---------------------------");
            }
            Process.Start(writePath);
        }

        private static StrAndCounts Counts(object obj)
        {
            str.Words_Count = 1;
            foreach (var item in str.Str)
                if (item == ' ')
                    str.Words_Count++;

            foreach (var item in str.Str)
                if (item == '.' || item == '!' || item == '?')
                {
                    str.Sentence_Count++;
                    if (item == '!')
                        str.NotQuestion_Count++;
                    else if (item == '?')
                        str.Question_Count++;
                }

            return str;
        }
        private static async Task<StrAndCounts> CountsAsync(object str)
        {
            return await Task.Run(() => (Counts(str)));
        }
    }
}
