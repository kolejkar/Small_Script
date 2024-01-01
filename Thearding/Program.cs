using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Proces proces = new Proces(args[0]);
                proces.Run();
            }
            Console.WriteLine("=== FINISH! ===");
            Console.ReadKey();
        }
    }
}
