using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class CombatAction : Action
    {
        public int Damage { get; set; }
        public int DamgeToArmor { get; set; }


        public CombatAction(string name, Target target, string sucessMessage,string failureMessage, int chanceOfSuccess, int damage):base(name,target,sucessMessage,failureMessage,chanceOfSuccess)
        {
            Damage = damage;
        }
        public bool Execute(Creature target)
        {
            
            if (base.Target == Target.Creature||(base.Target==Target.Self&&target.Name=="Player"))
            {
                System.Threading.Thread.Sleep(500);
                if (Program.random.Next(100) <= ChanceOfSuccess)
                {
                    Console.WriteLine(this.SucessMessage + $" {target.Name}");
                    if(Damage>0)
                        target.TakeHit(Damage);
                    if (DamgeToArmor > 0)
                    {
                        target.Armour -= DamgeToArmor;
                    }
                    return true;
                }
                Console.WriteLine(this.FailureMessage+ $" {target.Name}");
                return false;
            }
            else
                Console.WriteLine("Invalid target");return false;
        }
        public bool Execute(Creature target, int damageMod,int hitMod)
        {

            if (base.Target == Target.Creature || (base.Target == Target.Self && target.Name == "Player"))
            {
                System.Threading.Thread.Sleep(500);
                if (Program.random.Next(100) <= ChanceOfSuccess+hitMod)
                {
                    Console.WriteLine(this.SucessMessage + $" {target.Name}");
                    if (Damage > 0)
                        target.TakeHit(Damage);
                    if (DamgeToArmor > 0)
                    {
                        target.Armour -= DamgeToArmor;
                    }
                    return true;
                }
                Console.WriteLine(this.FailureMessage + $" {target.Name}");
                return false;
            }
            else
                Console.WriteLine("Invalid target"); return false;
        }
        public bool Execute(List<Creature> creatures)
        {
            if (base.Target == Target.Multiple)
            {
                if (Program.random.Next(100) <= ChanceOfSuccess)
                {
                    foreach(Creature target in creatures)
                    {
                        target.TakeHit(Damage);
                    }return true;
                }
                
            }
            return false;

        }
        

             
    }
}
