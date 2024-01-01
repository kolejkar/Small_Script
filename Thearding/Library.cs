using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    public enum Import_Result : int
    {
        OK,
        NotReturn,
        FunctonBad,
        BadResult
    }

    public interface Library
    {
         Import_Result RunLibraryFunction(string FuncName);
    }
}
