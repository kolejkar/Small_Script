using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thearding
{
    public class ListVaribles : Varible
    {
        private List<Varible> variblesList;

        public ListVaribles()
        {
            this.variblesList = new List<Varible>();
            this.value = null;
        }

        public ListVaribles(string name)
        {
            this.variblesList = new List<Varible>();
            this.value = "0"; //size of list
            this.name = name;
        }

        /*
         * LIST CREATE NAME
         * LIST NAME ADD VARIBLE
         * LIST NAME CLEAR ALL
         * LIST NAME CLEAR VARIBLE
         * LIST NAME GET I //1 - first index, 0 - empty
         * LIST NAME REMOVE I
         */

        public void OprtationVarible(string instruction, Varible varible)
        {
            if (instruction == "ADD")
            {
                variblesList.Add(varible);
                this.value = variblesList.Count.ToString();
            }
            if (instruction == "CLEAR")
            {
                if (varible.name == "ALL")
                {
                    variblesList.Clear();
                    this.value = variblesList.Count.ToString();
                }
                else
                {
                    variblesList.Remove(varible);
                    this.value = variblesList.Count.ToString();
                }
            }
        }

        public Varible OprtationInt(string instruction, int id)
        {
            if (instruction == "GET")
            {
                return variblesList[id-1];
            }
            if (instruction == "REMOVE")
            {
                variblesList.RemoveAt(id);
                this.value = variblesList.Count.ToString();
            }            
            return new Varible();
        }
    }
}
