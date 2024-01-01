using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    public class Import
    {
        private string LibraryName,FuncName;

        private Proces library;

        public Varible return_varible;

        public Import(string libraryName)
        {
            LibraryName = libraryName;
            library = new Proces(LibraryName);
        }

        public Import_Result Run(string function)
        {
            FuncName = function;
            Import_Result result = library.RunLibraryFunction(FuncName);
            if (result == Import_Result.OK)
            {
                return_varible = new Varible(library.return_varible);
            }
            return result; 
        }

        public string ResultErrorMsg(Import_Result result)
        {
            string msg = String.Format("Library {0}: Function {1} has no errors.", LibraryName, FuncName);
            if (result == Import_Result.FunctonBad)
            {
                msg = String.Format("Funcion {0} not found in library {1}.", FuncName, LibraryName);
            }
            if (result == Import_Result.NotReturn)
            {
                msg = String.Format("Library {0}: Function {1} not returned the value.", LibraryName, FuncName);
            }
            if (result == Import_Result.BadResult)
            {
                msg = String.Format("Library {0}: Function {1} has error in function code.", LibraryName, FuncName);
            }
            return msg;
        }
    }
}
