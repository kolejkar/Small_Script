using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    public abstract class TheardController
    {
        public List<Varible> varibles;
        public List<Funkcja> funkcje;
        public string[] words;
        public int iter;

        public void DefineFuncError()
        {
            Console.WriteLine(String.Format("Error at word {0}. Function {1} is not defined.", iter, words[iter]));
        }

       public void DivideError()
        {
            Console.WriteLine(String.Format("Error at word {0}. Division by zero. Varilbe {1} must be different from zero.", iter, words[iter]));
        }

        public void DefineError()
        {
            Console.WriteLine(String.Format("Error at word {0}. Varilbe {1} is not defined.", iter, words[iter]));
        }

        public void FormatWarning()
        {
            Console.WriteLine(String.Format("Warrning at word {0}. Varilbe {1} must be number.", iter, words[iter]));
        }

        public void ArgumentError()
        {
            Console.WriteLine(String.Format("error at word {0}. Invalid argument {1}.", iter, words[iter]));
        }
    }
}
