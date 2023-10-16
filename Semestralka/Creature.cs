using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class Creature
    {
        public int HP { get; set; }
        public int Wounds { get; set; }
        public string Name { get; set; }
        public int Armour { get; set; }
        public List<CombatAction> Actions = new List<CombatAction>();
        
        

        public Creature(int hp,string name)
        {
            HP = hp;
            Wounds = 0;
            Name = name;
            AddAction(new CombatAction("Unarmed weapon", Target.Creature, $"{this.Name} punches ",$"{this.Name} misses with it's punch", 35, 2));
            Armour = 0;            
        }
        public Creature()
        {
            HP = 1;
            Wounds = 0;
            Name = "Not Defined";
            AddAction(new CombatAction("Unarmed weapon", Target.Creature, $"{this.Name} punches ", $"{this.Name} misses with it's punch", 35, 2));
            Armour = 0;
        }
        public Creature(int hp, string name, int armour)
        {
            HP = hp;
            Wounds = 0;
            Name = name;
            AddAction(new CombatAction("Unarmed weapon", Target.Creature, $"{this.Name} punches ", $"{this.Name} misses with it's punch", 35, 2));
            Armour = armour;
        }

        public void TakeHit(int damage)
        {
            if (damage > 0)
            {
                Console.WriteLine($"{Name} is taking {damage - Armour} points of damage");
                if (damage > Armour)
                    Wounds += damage - Armour;
                else
                    Console.WriteLine("It was absorbed though");
            }
            else
            {
                Console.WriteLine($"{Name} is healed for {-damage} hp\n");
                Wounds += damage;
            }

            if (Wounds >= HP)
            {
                Console.WriteLine($"{Name} has been slain");
            }
            if (Wounds<0)
            {
                Wounds = 0;
            }
            Console.WriteLine($"{Name} ({HP - Wounds}/{HP})\n");
            
        }
        public void AddAction(CombatAction action)
        {
            Actions.Add(action);
        }
        public Creature copyCreature()
        {
            Creature creature = new Creature(HP, Name, Armour);
            creature.Actions = this.Actions;
            return creature;
        }
        
    }
}
