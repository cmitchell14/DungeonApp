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
                    System.Threading.Thread.Sleep(2500);
                    Console.ForegroundColor = ConsoleColor.Black;
                }//END IF damageDealt
                
            }//END If successful Attack
            else
            {
                Console.WriteLine($"{attacker.Name} has missed.");
                System.Threading.Thread.Sleep(2500);
            }//END else
        }//END Attack()



        public static void Battle(Player player, Monster monster)
        {
            Attack(player, monster);
            if (monster.Health > 0)
            {
                Attack(monster, player);
            }//END if
        }//END Battle()


    }//END CLASS

}//END NAMESPACE
