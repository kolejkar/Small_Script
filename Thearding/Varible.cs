using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    public class Varible
    {
        public string name;
        public string value = "";

        public Varible(Varible varible)
        {
            name = varible.name;
            value = varible.value;

        }

        public Varible()
        {
        }
    }
}
