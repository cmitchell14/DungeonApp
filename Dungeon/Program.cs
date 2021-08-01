using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string gameTitle = "The Blunderous Escapades of the Elf";
            //Player Variables
            int playerGold = 0;
            string playerName;
            int playerXp = 0;
            Race playerRace = Race.Human;
            //Starter Weapon/Armor Creation
            Weapon starterWeapon = new Weapon("Baby Dagger", true, "The World's smallest dagger... basically garbage.", 5, 2, false, 0, 0);
            Armor starterArmor = new Armor("Rags", true, "  Literally a wash rag thrown over your shoulder... \n  more likely to make you sick than block a blow.", 1, 0);

            //Companion Variables

            //Enemy Variables

            //Title Screen & Intro
            Console.Title = gameTitle;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine($"\n\n\n\n\n\n                                                      WELCOME TO:\n\n\n\n                                        \"{gameTitle}\"\n\n\n\n\n\n\n\n\n\n\n\n\n\n");


            System.Threading.Thread.Sleep(2000);  //TODO Add back story and introduction.
            Console.WriteLine("\n  This is the Intro. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum.");

            Console.WriteLine("Press any key to start your journey...");
            Console.ReadKey(true);
            Console.Clear();

            Console.Write("Hi friend.  What is your name?"); //TODO Add Elf's name
            playerName = Console.ReadLine();
            Console.Clear();

            bool raceMenu = true;

            Console.Write($"\n\nHi {playerName}!!  I'm an elf.  What are you?");
            do
            {
                Console.WriteLine("\n\n  Choose Your Race:\n1) Human\n2) Elf\n3) Hobgoblin\n4) Orc\n5) Dwarf\n6) Goliath"); //TODO Add Class Descriptions
                ConsoleKey raceChoice = Console.ReadKey(true).Key;
                switch (raceChoice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        playerRace = Race.Human;
                        Console.WriteLine("  You're a human?  I've had tons of human friends!!");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        playerRace = Race.Elf;
                        Console.WriteLine("  You're and elf like me?!  That's fantastic!");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        playerRace = Race.Hobgoblin;
                        Console.WriteLine("  A hobgoblin?  You must be pretty good with magic then.");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        playerRace = Race.Orc;
                        Console.WriteLine("  You.... you are an orc?  Please don't club me... ");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        playerRace = Race.Dwarf;
                        Console.WriteLine("  A dwarf?  I should've guessed by your small but strong stature.");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        playerRace = Race.Goliath;
                        Console.WriteLine("  Of course you're a goliath... you're massive.");
                        raceMenu = false;
                        break;
                    default:
                        Console.WriteLine($"  {raceChoice} is not a valid option.  Please choose again.");
                        break;
                }//END Race Switch

            } while (raceMenu); //END Do Loop

            Console.WriteLine($"  {playerName} the {playerRace}!  I need your help...  and seeing \n  as how you're stuck here, you might as well come with me.");
            Console.ReadKey(true);


            //Player Creation
            Player player = new Player(playerName, 60, 60, 60, 15, 60, 60, 5, 5, playerRace, starterWeapon, starterArmor, 1, 5);
            Companion elfCompanion = new Companion("Snushbat", 50, 20, 70, 85, 645, 0, 8, 10, 1, 19, player.PlayerLevel, 1, 1, 12);


            //New Title Creation
            Console.Title = $"   {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}                                   {gameTitle}                                   Player Level: {player.PlayerLevel}    XP: {playerXp}";

            //Starter Enemy
            Monster homunculus = new Monster("Homunculus", 15, 0, 60, 4, 15, 0, 4, 2, 0, 4, 5 * player.PlayerLevel, "A small humanoid, not capable of much harm.", 0, 0, 0, new Random().Next(1, player.PlayerLevel > 1 ? player.PlayerLevel : 1), new Random().Next(2, 5));

            Console.Clear();

            Console.WriteLine("\n\n  Hey, I need to know if you can fight...\n\n  Let's attack that little guy over there to practice.");
            Console.ReadKey(true);
            //TODO Testing Battle sequence

            Monster[] monsters =
                {
                    homunculus
                };

            Monster monster = monsters[new Random().Next(monsters.Length)];

            bool exitBattle = false;
            do
            {
                Console.Title = $"   {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                             {gameTitle}                               Player Level: {player.PlayerLevel}    XP: {playerXp}";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("\n  See that little guy?  It's a ");
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"{monster.Name} " + "!!");
                Console.ForegroundColor = ConsoleColor.Black;
                System.Threading.Thread.Sleep(1500);
                Console.WriteLine("\n\n  Kill it!!!!");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("\n\n  You're fighting a " + monster.Name);
                Console.WriteLine("\n\nChoose an action:\n" +
                   "A)ttack\n" +
                   "F)lee\n" +
                   "V)iew Stats\n" +
                   "M)onster Stats");
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                Console.Clear();

                switch (userChoice)
                {
                    case ConsoleKey.A:
                        Combat.Battle(player, monster);
                        if (monster.Health <= 0)   //This is where you could add loot drops or add a menu to take a potion.  
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You killed the {monster.Name}!!!\n\nThe {monster.Name} dropped {monster.MonsterGold} gold pieces!!!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            System.Threading.Thread.Sleep(2000);
                            playerGold = playerGold + monster.MonsterGold;
                            playerXp = playerXp + monster.MonsterXp;
                            Console.ReadKey(true);
                            exitBattle = true;
                        }
                        break;
                    case ConsoleKey.F:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("RUN AWAY");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"The {monster.Name} attacks you as your turn to flee!");
                        Combat.Attack(monster, player);
                        break;
                    case ConsoleKey.V:
                        Console.WriteLine(player);
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine(monster);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("You quit so soon?... Your cowardess saddens me...");
                        exitBattle = true;
                        break;
                    default:
                        Console.WriteLine("Thou hast choseneth an ivalideth optioneth.");
                        break;
                }

                if (player.Health < 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine($"You've been slain by {monster.Name}...");
                    Console.ReadKey(true);
                    exitBattle = true;
                }

            } while (!exitBattle);

            Console.WriteLine($"  That was great {player.Name}!!  Not at all impressive \n   considering your competition, but at least I know \n  you can stab a tiny helpless being to death!!");
            Console.WriteLine($"\n\n Excuse me for not introducing myself earlier.\n  My name is {elfCompanion.Name}.  I'm looking for some\n  of my friends.  They are all helpless humans.\n  Would you mind helping me find them?");

            //Homunculus 

            //An ancient elf recruits you to help him reconnect with all his old human friends. 
            //Turns out they have all been dead for centuries and many are the subjects of the epics songs by bards.
            //Comedic when all the bards songs are about dying in the most humiliating ways possible.



        }//END MAIN()

    }//END CLASS

}//END NAMESPACE
