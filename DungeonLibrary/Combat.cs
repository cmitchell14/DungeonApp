using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        //Method Functionality

        public static void Attack(Character attacker, Character defender)
        {
            //Use a dice roll from 1 - 100 to use as a basis to determine if the attacker hits.
            int diceRoll = new Random().Next(1, 101);
            System.Threading.Thread.Sleep(40);
            if (diceRoll <= attacker.CalcHitChance())
            {
                int damageDealt = attacker.CalcDamage() - defender.CalcArmor() / 4;
                if (damageDealt <= 0)
                {
                    damageDealt = 1;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{attacker.Name} hits {defender.Name} for {damageDealt} damage!!");
                    defender.Health -= damageDealt;
                    System.Threading.Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                else
                {
                    defender.Health -= damageDealt;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{attacker.Name} hits {defender.Name} for {damageDealt} damage!!");
                    System.Threading.Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Black;
                }//END IF damageDealt

            }//END If successful Attack
            else
            {
                Console.WriteLine($"{attacker.Name} has missed {defender.Name}.");
                System.Threading.Thread.Sleep(2000);
            }//END else
        }//END Attack()



        public static void Battle(Player player, Monster monster)
        {
            if (player.Initiative >= monster.Initiative)
            {
                Attack(player, monster);
                if (monster.Health > 0)
                {
                    Attack(monster, player);
                }
            }
            else
            {
                Attack(monster, player);
                if (player.Health > 0)
                {
                    Attack(player, monster);
                }

            }//END if
        }//END Battle()



        public static void Battle(Player player, Companion companion, Monster monster)
        {
            if (player.Initiative >= monster.Initiative && player.Initiative >= companion.Initiative)
            {
                Attack(player, monster);
                if (monster.Health > 0)
                {
                    Attack(companion, monster);
                    if (monster.Health > 0)
                    {
                        Character[] heroes = { player, companion };
                        Random select = new Random();
                        Attack(monster, heroes[select.Next(0, 2)]);  // Randomly selects player or companion to attack.
                    }
                    
                }
            }
            else if (companion.Initiative > monster.Initiative)
            {
                Attack(companion, monster);
                if (monster.Health > 0)
                {
                    Attack(player, monster);
                    if (monster.Health > 0)
                    {
                        Character[] heroes = { player, companion };
                        Random select = new Random();
                        Attack(monster, heroes[select.Next(0, 2)]);
                    }
                    
                }
            }
            else
            {
                Character[] heroes = { player, companion };
                Random select = new Random();
                Attack(monster, heroes[select.Next(0, 2)]);
                if (player.Health > 0)
                {
                    Attack(player, monster);
                    if (monster.Health > 0)
                    {
                        Attack(companion, monster);
                    }
                    
                }
            }
        }//END 3 Person Battle()

    }//END CLASS

}//END NAMESPACE

