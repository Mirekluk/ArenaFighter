using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class Player:Creature
    {
        List<Item> invetory;
        public Player(int hp) : base(hp,"Player")
        {            
            Actions[0].ChanceOfSuccess = 40;
            Actions[0].SucessMessage = "You punch";
            Armour = 0;
            invetory = new List<Item>();
        }
        public void AddItemToInventory(Item item)
        {
            invetory.Add(item);
            if (item.Action!=null)
            {
                this.Actions.Add(item.Action);
            }
        }public bool RemoveFromInventory(string name)
        {
            return invetory.Remove(invetory.Find(x => x.Name == name));
        }

    }
}
