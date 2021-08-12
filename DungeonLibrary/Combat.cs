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
                    Console.WriteLine($"  {attacker.Name} hits {defender.Name} for {damageDealt} damage!!");
                    defender.Health -= damageDealt;
                    System.Threading.Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                else
                {
                    defender.Health -= damageDealt;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"  {attacker.Name} hits {defender.Name} for {damageDealt} damage!!");
                    System.Threading.Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.Black;
                }//END IF damageDealt

            }//END If successful Attack
            else
            {
                Console.WriteLine($"  {attacker.Name} has missed {defender.Name}.");
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
            else if (companion.Initiative >= monster.Initiative)
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

        // 4 Person Battle() Sequence

        public static void Battle(Player player, Companion companion, Monster monster, Monster monsterTwo)
        {
            if (player.Initiative >= monster.Initiative && player.Initiative >= companion.Initiative && player.Initiative >= monsterTwo.Initiative)
            {
                if (monster.Health > 0 && monsterTwo.Health > 0)
                {
                    bool exit = false;
                    while (!exit)
                    {
                        if (monster.Health > 0 && monsterTwo.Health > 0)
                        {
                            Console.Write($"\n  Select a Target:\n  1) {monster.Name}\n  2) {monsterTwo.Name}");
                            ConsoleKey attackSel = Console.ReadKey(true).Key;
                            Console.Clear();
                            switch (attackSel)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.O:
                                    Attack(player, monster);
                                    if (monster.Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n  The {monster.Name} has perished\n");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        System.Threading.Thread.Sleep(1500);

                                        if (monsterTwo.Health > 0)
                                        {
                                            Attack(companion, monsterTwo);
                                            if (monsterTwo.Health > 0)
                                            {
                                                Character[] heroes = { player, companion };
                                                Random select = new Random();
                                                Attack(monsterTwo, heroes[select.Next(0, 2)]);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Character[] baddies = { monster, monsterTwo };
                                        Random selectBad = new Random();
                                        Attack(companion, baddies[selectBad.Next(0, 2)]);
                                        if (monster.Health > 0 && monsterTwo.Health > 0)
                                        {
                                            Character[] heroes = { player, companion };
                                            Random select = new Random();
                                            Attack(monster, heroes[select.Next(0, 2)]);
                                            Attack(monsterTwo, heroes[select.Next(0, 2)]);
                                        }
                                        else if (monster.Health > 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"\n  The {monsterTwo.Name} has perished\n");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            System.Threading.Thread.Sleep(1500);
                                            Character[] heroes = { player, companion };
                                            Random select = new Random();
                                            Attack(monster, heroes[select.Next(0, 2)]);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"\n  The {monster.Name} has perished\n");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            System.Threading.Thread.Sleep(1500);
                                            Character[] heroes = { player, companion };
                                            Random select = new Random();
                                            Attack(monsterTwo, heroes[select.Next(0, 2)]);
                                        }
                                    }
                                    exit = true;
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                case ConsoleKey.T:
                                    Attack(player, monsterTwo);
                                    if (monsterTwo.Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n  The {monsterTwo.Name} has perished\n");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        System.Threading.Thread.Sleep(1500);
                                        if (monster.Health > 0)
                                        {
                                            Attack(companion, monster);
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
                                        Character[] baddies = { monster, monsterTwo };
                                        Random selectBad = new Random();
                                        Attack(companion, baddies[selectBad.Next(0, 2)]);
                                        if (monster.Health > 0 && monsterTwo.Health > 0)
                                        {
                                            Character[] heroes = { player, companion };
                                            Random select = new Random();
                                            Attack(monster, heroes[select.Next(0, 2)]);
                                            Attack(monsterTwo, heroes[select.Next(0, 2)]);
                                        }
                                        else if (monster.Health > 0)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"\n  The {monsterTwo.Name} has perished\n");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            System.Threading.Thread.Sleep(1500);
                                            Character[] heroes = { player, companion };
                                            Random select = new Random();
                                            Attack(monster, heroes[select.Next(0, 2)]);
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine($"\n  The {monster.Name} has perished\n");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            System.Threading.Thread.Sleep(1500);
                                            Character[] heroes = { player, companion };
                                            Random select = new Random();
                                            Attack(monsterTwo, heroes[select.Next(0, 2)]);
                                        }
                                    }
                                    exit = true;
                                    break;
                                default:
                                    Console.WriteLine("\n\n  You should probably attack one of the monsters...");
                                    System.Threading.Thread.Sleep(1500);
                                    break;
                            } //End switch selection
                        } //END player Choice Attack()
                    }//END player Attack Loop
                }
                else if (monster.Health > 0)
                {
                    Battle(player, companion, monster);
                }
                else
                {
                    Battle(player, companion, monsterTwo);
                }
            }//ENd if Player Initiative is highest.

            //Companion attacks first with two enemies.
            else if (companion.Initiative >= monster.Initiative && companion.Initiative >= monsterTwo.Initiative)
            {
                if (monster.Health > 0 && monsterTwo.Health > 0)
                {
                    Character[] baddies = { monster, monsterTwo };
                    Random selectBad = new Random();
                    Attack(companion, baddies[selectBad.Next(0, 2)]);
                    if (monster.Health > 0 && monsterTwo.Health > 0) //Both monsters alive after companion attack first.
                    {
                        bool exit2 = false;
                        while (!exit2)
                        {
                            Console.Write($"\n  Select a Target:\n  1) {monster.Name}\n  2) {monsterTwo.Name}");
                            ConsoleKey attackSel = Console.ReadKey(true).Key;
                            Console.Clear();
                            switch (attackSel)
                            {
                                case ConsoleKey.D1:
                                case ConsoleKey.NumPad1:
                                case ConsoleKey.O:
                                    Attack(player, monster);
                                    if (monster.Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n  The {monster.Name} has perished\n");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        System.Threading.Thread.Sleep(1500);
                                    }
                                    exit2 = true;
                                    break;
                                case ConsoleKey.D2:
                                case ConsoleKey.NumPad2:
                                case ConsoleKey.T:
                                    Attack(player, monsterTwo);
                                    if (monsterTwo.Health <= 0)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n  The {monsterTwo.Name} has perished\n");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        System.Threading.Thread.Sleep(1500);
                                    }
                                    exit2 = true;
                                    break;
                                default:
                                    Console.WriteLine("\n\n  You should probably attack one of the monsters...");
                                    System.Threading.Thread.Sleep(1500);
                                    break;
                            }//END player attack option switch
                        }//End player Attack loop
                        if (monster.Health > 0 && monsterTwo.Health > 0)
                        {
                            Character[] heroes = { player, companion };
                            Random select = new Random();
                            Attack(monster, heroes[select.Next(0, 2)]);
                            if (player.Health > 0)
                            {
                                Attack(monsterTwo, heroes[select.Next(0, 2)]);
                            }
                        }
                        else if (monster.Health > 0)
                        {
                            Character[] heroes = { player, companion };
                            Random select = new Random();
                            Attack(monster, heroes[select.Next(0, 2)]);
                        }
                        else
                        {
                            Character[] heroes = { player, companion };
                            Random select = new Random();
                            Attack(monsterTwo, heroes[select.Next(0, 2)]);
                        }

                    }//End If both monsters alive and player attacks.
                    else if (monster.Health > 0)
                    {
                        Attack(player, monster);
                        if (monster.Health > 0)
                        {
                            Character[] heroes = { player, companion };
                            Random select = new Random();
                            Attack(monster, heroes[select.Next(0, 2)]);
                        }
                    }
                    else
                    {
                        Attack(player, monsterTwo);
                        if (monsterTwo.Health > 0)
                        {
                            Character[] heroes = { player, companion };
                            Random select = new Random();
                            Attack(monsterTwo, heroes[select.Next(0, 2)]);
                        }
                    }
                }// End if both monsters still alive.
                else if (monster.Health > 0)
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
                } //End if monster still alive.
                else if (monsterTwo.Health > 0)
                {
                    Attack(companion, monsterTwo);
                    if (monsterTwo.Health > 0)
                    {
                        Attack(player, monsterTwo);
                        if (monsterTwo.Health > 0)
                        {
                            Character[] heroes = { player, companion };
                            Random select = new Random();
                            Attack(monsterTwo, heroes[select.Next(0, 2)]);
                        }
                    }
                }// End if monsterTwo still alive
            }//End companion attack first.

            //If monsters attack first
            else
            {
                if (monster.Health > 0 && monsterTwo.Health > 0)
                {
                    Character[] heroes = { player, companion };
                    Random select = new Random();
                    Attack(monster, heroes[select.Next(0, 2)]);
                    if (player.Health > 0)
                    {
                        Attack(monsterTwo, heroes[select.Next(0, 2)]);
                        if (player.Health > 0)   //Both monsters attacked and the player is still alive.
                        {
                            Character[] baddies = { monster, monsterTwo };
                            Random selectBad = new Random();
                            Attack(companion, baddies[selectBad.Next(0, 2)]);
                            if (monster.Health > 0 && monsterTwo.Health > 0)
                            {
                                bool exit2 = false;
                                while (!exit2)
                                {
                                    Console.Write($"\n  Select a Target:\n  1) {monster.Name}\n  2) {monsterTwo.Name}");
                                    ConsoleKey attackSel = Console.ReadKey(true).Key;
                                    Console.Clear();
                                    switch (attackSel)
                                    {
                                        case ConsoleKey.D1:
                                        case ConsoleKey.NumPad1:
                                        case ConsoleKey.O:
                                            Attack(player, monster);
                                            if (monster.Health <= 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"\n  The {monster.Name} has perished\n");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                System.Threading.Thread.Sleep(1500);
                                            }
                                            exit2 = true;
                                            break;
                                        case ConsoleKey.D2:
                                        case ConsoleKey.NumPad2:
                                        case ConsoleKey.T:
                                            Attack(player, monsterTwo);
                                            if (monsterTwo.Health <= 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"\n  The {monsterTwo.Name} has perished\n");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                System.Threading.Thread.Sleep(1500);
                                            }
                                            exit2 = true;
                                            break;
                                        default:
                                            Console.WriteLine("\n\n  You should probably attack one of the monsters...");
                                            System.Threading.Thread.Sleep(1500);
                                            break;
                                    }//END player attack option switch
                                }//End player Attack loop
                            }
                            else if (monster.Health > 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n  The {monsterTwo.Name} has perished\n");
                                Console.ForegroundColor = ConsoleColor.Black;
                                System.Threading.Thread.Sleep(1500);
                                Attack(player, monster);
                            } //End if only monster lives
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"\n  The {monster.Name} has perished\n");
                                Console.ForegroundColor = ConsoleColor.Black;
                                System.Threading.Thread.Sleep(1500);
                                Attack(player, monsterTwo);
                            } //End if only monsterTwo lives
                        }//End if player still alive 2
                    }//End if Player alive 1
                }//End if both monsters still alive.
                else if (monster.Health > 0)
                {
                    Battle(player, companion, monster);
                }//End if monster only one alive
                else
                {
                    Battle(player, companion, monsterTwo);
                }//End if monsterTwo only one alive
            }// End if monster Initiative is highest.

        }//END 4 Person Battle()


    }//END CLASS

}//END NAMESPACE



