using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class CombatEvent : Event
    {
        public Player Player { get; set; }
        public List<Creature> Enemies { get; set; }
        public List<Creature> Allies { get; set; }
        public List<Item> Loot { get; set; }
        //Player vs monsters
        public CombatEvent(string name, Player player, List<Creature> enemies) : base(name)
        {
            Player = player;
            Enemies = enemies;
        }
        public CombatEvent(string name, Event e, Player player, List<Creature> enemies) : base(name, e)
        {
            Player = player;
            Enemies = enemies;
        }
        public CombatEvent(string name, List<Event> followers, Player player, List<Creature> enemies) : base(name, followers)
        {
            Player = player;
            Enemies = enemies;
        }
        //Player + monsters vs Monsters
        public CombatEvent(string name, Player player, List<Creature> enemies, List<Creature> allies) : base(name)
        {
            Player = player;
            Enemies = enemies;
            Allies = allies;
        }
        public CombatEvent(string name, Event e, Player player, List<Creature> enemies, List<Creature> allies) : base(name, e)
        {
            Player = player;
            Enemies = enemies;
            Allies = allies;
        }
        public CombatEvent(string name, List<Event> followers, Player player, List<Creature> enemies, List<Creature> allies) : base(name, followers)
        {
            Player = player;
            Enemies = enemies;
            Allies = allies;
        }


        new public bool Execute()
        {
            while (true)
            {
                Console.WriteLine("Next turn\n");
                //Player's turn
                while (true)
                {
                    Console.WriteLine("What do you want to do?\n");
                    foreach (CombatAction action in Player.Actions)
                    {
                        Console.WriteLine($"{action.Name}");
                    }
                    string choice_actionName = Console.ReadLine();
                    int choice_numeral=-1;
                    int.TryParse(choice_actionName,out choice_numeral);
                    if (Player.Actions.Exists(x => x.Name == choice_actionName)||(choice_numeral!=-1&&choice_numeral>0&&choice_numeral<Player.Actions.Count))
                    {
                        CombatAction action;
                        if (choice_numeral != -1)
                        {
                            action = Player.Actions.ElementAt(choice_numeral);
                        }
                        else {
                            action = Player.Actions.Find(x => (x.Name == choice_actionName));
                        }
                        
                        if (action.Target == Target.Creature)
                        {
                            Console.WriteLine("\nWhich creature do you want to target?");
                            int targetIndex = 1;
                            foreach (Creature creature in Enemies)
                            {
                                Console.WriteLine($"{Enemies.IndexOf(creature) + 1}){creature.Name} ({creature.HP-creature.Wounds}/{creature.HP})");
                            }
                            targetIndex = PickTarget() - 1;
                            bool hitp = action.Execute(Enemies[targetIndex]);
                            if (hitp)
                            {

                                if (Enemies[targetIndex].Wounds >= Enemies[targetIndex].HP)
                                {
                                    Enemies.RemoveAt(targetIndex);
                                    if (Enemies.Count == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        break;
                    }
                    else
                        Console.WriteLine($"{choice_actionName} is not valid");

                }//End of Player's turn
                if (Allies != null)
                {
                    foreach (Creature ally in Allies)
                    {
                        Creature target = Enemies.Aggregate((agg, next) =>
                                                        next.Wounds > agg.Wounds ? next : agg);
                        CombatAction action = ally.Actions.Aggregate((agg, next) =>
                             next.Damage > agg.Damage ? next : agg);
                        bool hitp = action.Execute(target);
                        if (hitp && target.Wounds > target.HP)
                        {
                            Enemies.Remove(target);

                        }
                    }
                }
                if (Enemies != null)
                {
                    foreach (Creature enemy in Enemies)
                    {
                        CombatAction action = enemy.Actions.Aggregate((agg, next) =>
                             next.Damage > agg.Damage ? next : agg);
                        List<Creature> copy = new List<Creature>();
                        if (Allies!=null)
                        {
                           copy = Allies.ToList();
                        }                        
                        copy.Add(Player);
                        Creature target = copy.Aggregate((agg, next) =>
                                             next.Wounds > agg.Wounds ? next : agg);
                        bool hitp = action.Execute(target);
                        if (hitp && target.Wounds >= target.HP)
                        {
                            if (target == Player)
                            {

                                Console.WriteLine("This is the end");
                                Console.ReadKey();
                                return false;
                            }
                            else
                                Allies.Remove(target);

                        }
                    }
                }
            }
        }
        private int PickTarget()
        {

            int target = 0;
            do
            {
                try
                {
                    target = Convert.ToInt32(Console.ReadLine());
                    if (target <= Enemies.Count + 1 && target > 0)
                        return target;
                    else
                        Console.WriteLine("You must pick from options above");

                }

                catch (FormatException ex)
                {
                    
                    Console.WriteLine("Use numbers please. Only numbers.");
                }
            }
            while (true);


        }

    }
}
