using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary;

namespace ConsoleApp
{
    class Program
    {
        DataManager db;

        static void Main(string[] args)
        {
            new Program().Run();
        }

        private Program()
        {
            db = new DataManager();
        }

        private void Run()
        {
            Console.Write("Enter data in csv format, or\n  q to quit\n  p to dump data\n\n");
            while(true)
            {
                string line = Console.ReadLine();
                if (line.Equals("q")) {
                    // q means quit
                    break;
                }
                else if (line.Equals("p"))
                {
                    // p means print
                    db.DumpTo(Console.Out);
                }
                else
                {
                    ProcessLine(line);
                }
            }
        }

        private void ProcessLine(string line)
        {
            try
            {
                db.AddItem(NamedPoint.Parse(line));
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: {0}", ex);
            }
        }
    }
}
