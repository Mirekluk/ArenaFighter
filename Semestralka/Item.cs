using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class Item
    {
        public string Name { get; set; }
        public CombatAction Action { get; set; }
        public Item (string name)
        {
            this.Name = name;
        }
        public Item(string name,CombatAction action)
        {
            Name = name;
            Action = action;
        }
    }
}
