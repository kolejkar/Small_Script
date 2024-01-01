using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    public class Cpu_If : TheardController
    {
        private int flag_if = 0;

        public Cpu_If(List<Varible> varibles, List<Funkcja> funkcje, string[] words, int iter)
        {
            this.varibles = varibles;
            this.funkcje = funkcje;
            this.words = words;
            this.iter = iter;
        }

        public int getPosition()
        {
            return iter;
        }

        private string var1;
        private string var2;
        private string typ;

        public Import_Result Check()
        {
            iter++;
            LoadVaribles();

            Import_Result result;

            flag_if = var1.CompareTo(var2);
            if (typ == "==" && flag_if == 0)
            {
                result=Compare1();
            }
            else
            if (typ == "!=" && flag_if != 0)
            {
                result=Compare2();
            }
            else
            if ((typ == ">" || typ == "<=") && flag_if > 0)
            {
                result=Compare3();
            }
            else
            if ((typ == "<" || typ == ">=") && flag_if < 0)
            {
                result=Compare4();
            }
            else
            {
                iter++;
                result = Import_Result.OK;
            }
            return result;
        }

        private void LoadVaribles()
        {
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var1 = varibles.Find(v => v.name == words[iter]).value;
            }
            else
            {
                var1 = words[iter];
            }
            typ = words[++iter];
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var2 = varibles.Find(v => v.name == words[iter]).value;
            }
            else
            {
                var2 = words[iter];
            }
        }

        private Funkcja funkcja;

        public Funkcja getNewFunction()
        {
            return funkcja;
        }

        private Import_Result Compare1()
        {
            try
            {
                iter = int.Parse(words[++iter]);
            }
            catch (FormatException)
            {
                if (funkcje.Exists(f => f.name == words[iter]))
                {
                    funkcja = funkcje.Find(f => f.name == words[iter]);
                    funkcja.current = iter;
                    iter = funkcja.jump_to;
                    //stack_function.Push(funkcja);
                }
                else
                {
                    DefineError();
                    return Import_Result.BadResult;
                }
            }
            return Import_Result.OK;
        }

        private Import_Result Compare2()
        {
            try
            {
                iter = int.Parse(words[++iter]);
            }
            catch (FormatException)
            {
                if (funkcje.Exists(f => f.name == words[iter]))
                {
                    funkcja = funkcje.Find(f => f.name == words[iter]);
                    funkcja.current = ++iter;
                    iter = funkcja.jump_to;
                    //stack_function.Push(funkcja);
                }
                else
                {
                    DefineError();
                    return Import_Result.BadResult;
                }
            }
            return Import_Result.OK;
        }

        private Import_Result Compare3()
        {
            try
            {
                iter = int.Parse(words[++iter]);
            }
            catch (FormatException)
            {
                if (funkcje.Exists(f => f.name == words[iter]))
                {
                    funkcja = funkcje.Find(f => f.name == words[iter]);
                    funkcja.current = iter;
                    iter = funkcja.jump_to;
                    //stack_function.Push(funkcja);
                }
                else
                {
                    DefineError();
                    return Import_Result.BadResult;
                }
            }
            return Import_Result.OK;
        }

        private Import_Result Compare4()
        {
            try
            {
                iter = int.Parse(words[++iter]);
            }
            catch (FormatException)
            {
                if (funkcje.Exists(f => f.name == words[iter]))
                {
                    funkcja = funkcje.Find(f => f.name == words[iter]);
                    funkcja.current = iter;
                    iter = funkcja.jump_to;
                    //stack_function.Push(funkcja);
                }
                else
                {
                    DefineError();
                    return Import_Result.BadResult;
                }
            }
            return Import_Result.OK;
        }
    }
}
