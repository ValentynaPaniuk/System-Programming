using System;

using System.Collections.Generic;

using System.Diagnostics;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace _Task_Part2
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = { "Ivan", "Sergii", "Olexandr", "Stepan", "Olia", "Svitlana", "Ania", "Snizhana" };



            //var res = names.AsParallel().Where(x => x.StartsWith("S"));

            //foreach (var item in res)

            //{

            //    Console.WriteLine("Result:" + item);

            //}

            while (true)

            {

                Console.WriteLine("Enter any key to start calculation");

                Console.ReadLine();

                Task.Factory.StartNew(ProcessNumbers);

                Console.WriteLine("Processing....");

            }

        }

        public static void ProcessNumbers()

        {

            var numbers = Enumerable.Range(0, 9000000);

            // timer, секундомір

            Stopwatch watch = new Stopwatch();

            watch.Start();
            (from i in numbers
             where i % 3 == 0
             select i).ToArray().AsParallel().ForAll(x => Console.WriteLine(x));

            watch.Stop();


            Console.WriteLine(" ----- time: {0} ms", watch.ElapsedMilliseconds);


        }

    }
}


