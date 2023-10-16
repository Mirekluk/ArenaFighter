using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralka
{
    class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            Player player = new Player(20)
            {
                Armour = 2
            };
            Console.WriteLine("Welcome to the Arena brave warrior. Before you have your first round, you must choose your weapon.");
            Console.WriteLine("1) Shortsword :55% chance to hit, 6 damage ");
            Console.WriteLine("2) Battleaxe : 45% chance to hit, 8 damge");
            Console.WriteLine("3) Pair of daggers: 70% chance to hit 4 damage");
            Console.WriteLine("For you I have something else up my sleeve. Dart of Corrosion : 30% chance to hit, reduces opponents armor by 1");
            bool choiceLoop = true;
            while (choiceLoop)
            {
                string choice = Console.ReadLine();
                switch (Convert.ToInt32(choice))
                {
                    case 1:
                        player.AddItemToInventory(new Item("Shortsword", new CombatAction("Shortsword attack", Target.Creature, "You slash", "Your shortsword is unable to hit", 55, 6)));
                        choiceLoop = false;
                        break;
                    case 2:
                        player.AddItemToInventory(new Item("Battleaxe", new CombatAction("Battleaxe attack", Target.Creature, "You swing your battleaxe and hit", "You were unable to hit", 45, 8)));
                        choiceLoop = false;
                        break;
                    case 3:
                        player.AddItemToInventory(new Item("Pair of daggers", new CombatAction("Dagger attack", Target.Creature, "You stab", "You haven't found opening to hit", 70, 4)));
                        choiceLoop = false;
                        break;                    
                }
            }
            player.AddItemToInventory(new Item("Dart of Corrosion", new CombatAction("Dart of Corrosion", Target.Creature, "You manage to land a hit and reduce armor of", "You missed", 30, 0)));
            player.Actions[player.Actions.FindIndex(x => x.Name == "Dart of Corrosion")].DamgeToArmor = 1;
            CombatAction goblinDagger = new CombatAction("goblin dagger", Target.Creature, "Goblin manages to find opening and stabs", "Goblin failed to stab", 60, 3);
            CombatAction goblinBow = new CombatAction("Goblin bow", Target.Creature, "Goblin shoots", "Goblin's arrow misses", 45, 4);
            List<Creature> currentEnemies = new List<Creature>()
            {
                new Creature(6,"Goblin Gurig",2),new Creature(6,"Goblin Pebble",2),new Creature(6,"Goblin Kuz",2)
            };
            currentEnemies[0].AddAction(goblinDagger);
            currentEnemies[1].AddAction(goblinDagger);
            currentEnemies[2].AddAction(goblinBow);
            CombatEvent combat = new CombatEvent("Three lowly goblins", player, currentEnemies);
            if(!combat.Execute())
            {
                return ;
            }
            Console.WriteLine("Congratulations, you survived the goblins. Now you can either increase MaxHP, or take better armor");
            Console.WriteLine("1) increase your maximum HP up to 30.");
            Console.WriteLine("2) increase your armor by 2 ");
            choiceLoop = true;
            while (choiceLoop)
            {
                string choice = Console.ReadLine();
                switch (Convert.ToInt32(choice))
                {
                    case 1:
                        player.HP = 30;
                        player.Wounds = 0;
                        choiceLoop = false;
                        break;
                    case 2:
                        player.Armour += 2;
                        player.Wounds = 0;
                        choiceLoop = false;
                        break;
                    default:
                        Console.WriteLine("Vybírejte prosím jen z uvedených možností napsáním čísla 1 nebo 2");
                        break;
                }
            }
            Console.WriteLine("Good, now you will fight with Gorrion brothers.");
            currentEnemies = new List<Creature>()
            {
                new Creature(15,"Lucius Gorrion",6),new Creature(20,"Phobius Gorrion",4)
            };
            currentEnemies[0].AddAction(new CombatAction("Warhammer", Target.Creature, "Lucius Gorrion swing his Warhammer and smashes", "Lucius fails to hit", 50, 5));
            currentEnemies[1].AddAction(new CombatAction("Longbow", Target.Creature, "Phobius Gorrion shoots", "Phobius fails to hit", 45, 6));
            combat = new CombatEvent("Gorrion Brothers", player, currentEnemies);
            if (!combat.Execute()) 
            {
                return;
            }
            Console.WriteLine("Excelent. You defeated the Gorrion Brothers, the only other survivors. That makes you the champion of this tournament");
            








        }
    }
}
