using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    public class Proces : TheardController, Library
    {
        private string[] linie;

        private Stack<Funkcja> stack_function;

        public Varible return_varible;

        public Proces(string name)
        {
            words = new string[] { "" };
            linie = System.IO.File.ReadAllLines(name);
            foreach (string word in linie)
            {
                    words = words.Concat(word.Split(new char[] { ' ', '\n', '\r' })).ToArray();
            }
            varibles = new List<Varible>();
            //arytmetic register
            Varible varible = new Varible();
            varible.name = "ALU_RESULT";
            varible.value = "";
            varibles.Add(varible);
            funkcje = new List<Funkcja>();
            stack_function = new Stack<Funkcja>();
            FindFunkcions();
        }

        private void FindFunkcions()
        {
            int poz = 0;
            while (words.Length != poz)
            {
                if (words[poz] == "FUNC")
                {
                    poz++;
                    Funkcja funkcja = new Funkcja();
                    funkcja.name = words[poz];
                    funkcja.jump_to = poz;
                    funkcje.Add(funkcja);
                }
                poz++;
            }
        }

        public void Run()
        {
            RunLibraryFunction("MAIN");
        }

        public bool CheckFunction(string FuncName)
        {
            if (funkcje.Exists(f => f.name == FuncName))
            {
                iter = funkcje.Find(f => f.name == FuncName).jump_to;
                stack_function.Push(funkcje.Find(f => f.name == FuncName));
            }
            else
            if (FuncName == "MAIN")
            {
                iter = 0;
                Funkcja funkcja = new Funkcja();
                funkcja.name = FuncName;
                funkcja.jump_to = 0;
                stack_function.Push(funkcja);
            }
            else
            {
                DefineFuncError();
                return false;
            }
            return true;
        }

        public void PrintFunction()
        {
            iter++;

            if (words[iter] == "$clear")
            {
                Console.Clear();
            }
            else
            if (varibles.Exists(v => v.name == words[iter]))
            {
                Console.WriteLine(SpecialChars(varibles.Find(v => v.name == words[iter]).value));
            }
            else
            {
                Console.WriteLine(SpecialChars(words[iter]));
            }
        }

        public bool MoveFunction()
        {
            try
            {
                iter = int.Parse(words[++iter]);
            }
            catch (FormatException)
            {
                if (funkcje.Exists(f => f.name == words[iter]))
                {
                    Funkcja funkcja = funkcje.Find(f => f.name == words[iter]);
                    funkcja.current = iter;
                    iter = funkcja.jump_to;
                    stack_function.Push(funkcja);
                }
                else
                {
                    DefineFuncError();
                    return true;
                }
            }
            return false;
        }

        public bool SetFunction()
        {
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                Varible varible = varibles.Find(v => v.name == words[iter]);
                iter++;
                if (varibles.Exists(v => v.name == words[iter]))
                {
                    varible.value = varibles.Find(v => v.name == words[iter]).value;
                }
                else
                {
                    varible.value = words[iter];
                }
            }
            else
            {
                DefineError();
                return true;
            }
            return false;
        }

        public bool AddFunction()
        {
            Varible var1, var2;
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var1 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var2 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            try
            {
                float sum = float.Parse(var1.value) + float.Parse(var2.value);
                var1.value = sum.ToString();
            }
            catch (FormatException)
            {
                var1.value = var1.value + var2.value;
            }
            return false;
        }

        public bool SubFunction()
        {
            Varible var1, var2;
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var1 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var2 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            try
            {
                float sum = float.Parse(var1.value) - float.Parse(var2.value);
                var1.value = sum.ToString();
            }
            catch (FormatException)
            {
                FormatWarning();
            }
            return false;
        }

        public bool DivideFunction()
        {
            Varible var1, var2;
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var1 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var2 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            try
            {
                float sum = float.Parse(var1.value) / float.Parse(var2.value);
                var1.value = sum.ToString();
            }
            catch (FormatException)
            {
                FormatWarning();
            }
            catch (DivideByZeroException)
            {
                DivideError();
                return true;
            }
            return false;
        }

        public bool MulFunction()
        {
            Varible var1, var2;
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var1 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                var2 = varibles.Find(v => v.name == words[iter]);
            }
            else
            {
                DefineError();
                return true;
            }
            try
            {
                float sum = float.Parse(var1.value) * float.Parse(var2.value);
                var1.value = sum.ToString();
            }
            catch (FormatException)
            {
                FormatWarning();
            }
            return false;
        }

        public bool ImportModuleFunction()
        {
            string fileName, func;
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                fileName = varibles.Find(v => v.name == words[iter]).value;
            }
            else
            {
                fileName = words[iter];
            }
            Import import = new Import(fileName);
            iter++;
            if (varibles.Exists(v => v.name == words[iter]))
            {
                func = varibles.Find(v => v.name == words[iter]).value;
            }
            else
            {
                func = words[iter];
            }
            iter++;
            Import_Result result = import.Run(func);
            if (result == Import_Result.OK)
            {
                Varible varible = new Varible();
                varible.name = words[iter];
                varible.value = import.return_varible.value;
                varibles.Add(varible);
            }
            else
            {
                Console.WriteLine(import.ResultErrorMsg(result));
                return true;
            }
            /*if (words[iter] == "$clear")
            {
                Console.Clear();
            }*/
            return false;
        }

        public Import_Result RunLibraryFunction(string FuncName)
        {
            if (!CheckFunction(FuncName))
            {
                return Import_Result.FunctonBad;
            }
            while (words.Length != iter)
            {
                if (words[iter] == "PRINT") //write in console
                {
                    PrintFunction();
                }
                if (words[iter]  == "EXIT") //exit file
                {
                    iter = words.Length;
                    break;
                }
                if (words[iter] == "MOVE") //move in file
                {
                    if (MoveFunction())
                    {
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "VAR")  //define varible
                {
                    Varible varible = new Varible();
                    varible.name = words[++iter];
                    varibles.Add(varible);
                }
                if (words[iter] == "SET") //modyfiy varible
                {
                    if (SetFunction())
                    {
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "GET")
                {
                    ++iter;
                    if (varibles.Exists(v => v.name == words[iter]))
                    {
                        varibles.Find(v => v.name == words[iter]).value = Console.ReadLine();
                    }
                    else
                    {
                        DefineError();
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "IF")
                {
                    Cpu_If cpu_If = new Cpu_If(varibles, funkcje, words, iter);
                    Import_Result result = cpu_If.Check();
                    if (result != Import_Result.OK)
                    {
                        return result;
                    }
                    else
                    {
                        stack_function.Push(cpu_If.getNewFunction());
                        iter = cpu_If.getPosition();
                    }
                }
                if (words[iter] == "ADD")
                {
                    if (AddFunction())
                    {
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "SUB")
                {
                    if (SubFunction())
                    {
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "DIV")
                {
                    if (DivideFunction())
                    {
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "MUL")
                {
                    if (MulFunction())
                    {
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "RET")
                {
                    if (stack_function.Count > 0)
                    {
                        Funkcja funkcja = stack_function.Pop();
                        iter = funkcja.current;
                    }
                }
                if (words[iter] == "IMPORT")
                {
                    if (ImportModuleFunction())
                    {
                        return Import_Result.BadResult;
                    }
                }
                if (words[iter] == "RET_VAR")
                {
                    Varible var1;
                    iter++;
                    if (varibles.Exists(v => v.name == words[iter]))
                    {
                        var1 = varibles.Find(v => v.name == words[iter]);
                    }
                    else
                    {
                        DefineError();
                        return Import_Result.NotReturn;
                    }
                    return_varible = new Varible(var1);
                }
                iter++;
            }
            return Import_Result.OK;
        }

        private string SpecialChars(string text)
        {
            return text.Replace("$n", "\n").Replace("$s", " ").Replace("$$", "$").Replace("$t", "\t");
        }
    }
}
