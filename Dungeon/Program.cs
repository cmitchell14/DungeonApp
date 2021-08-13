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
            string playerName;
            Race playerRace = Race.Human;
            //Starter Weapon/Armor Creation
            Weapon starterWeapon = new Weapon("Baby Dagger", true, "The World's smallest dagger... basically garbage.", 5, 2, false, 0, 0);
            Armor starterArmor = new Armor("Rags", true, "  Literally a wash rag thrown over your shoulder... \n  more likely to make you sick than block a blow.", 1, 0);

            //Enemy Variables

            //Title Screen & Intro
            Console.Title = gameTitle;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine(@"     


                                                    WELCOME TO:      

                                      ╔╦╗┬ ┬┌─┐  ╔╗ ┬  ┬ ┬┌┐┌┌┬┐┌─┐┬─┐┌─┐┬ ┬┌─┐  
                                       ║ ├─┤├┤   ╠╩╗│  │ ││││ ││├┤ ├┬┘│ ││ │└─┐  
                                       ╩ ┴ ┴└─┘  ╚═╝┴─┘└─┘┘└┘─┴┘└─┘┴└─└─┘└─┘└─┘");
            Console.WriteLine(@"                           
                             ╔═╗┌─┐┌─┐┌─┐┌─┐┌─┐┌┬┐┌─┐┌─┐  ┌─┐┌─┐  ┌┬┐┬ ┬┌─┐  ┌─┐┬  ┌─┐
                             ║╣ └─┐│  ├─┤├─┘├─┤ ││├┤ └─┐  │ │├┤    │ ├─┤├┤   ├┤ │  ├┤ 
                             ╚═╝└─┘└─┘┴ ┴┴  ┴ ┴─┴┘└─┘└─┘  └─┘└     ┴ ┴ ┴└─┘  └─┘┴─┘└ ");


            System.Threading.Thread.Sleep(2000);  //TODO Add back story and introduction.
            Console.WriteLine("\n  This is the Intro. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. \n  Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem \n  Ipsum lorem ipsum. Lorem Ipsum lorem ipsum. Lorem Ipsum lorem ipsum.");

            Console.WriteLine("\n\n  Press any key to start your journey...");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine(@"

                             ████████████████████████████████████████████████████████████████████████  
                             ██                                                                    ██
                             ██                 Hi friend.  What is your name?                     ██
                             ██                                                                    ██
                             █████████████████████████████████████████████████████████        ███████
                                                                                     ██      ██    
                                                                                      ██     █    
                                                                                       █    █    
                                                                                        █  █    
                                                                                         █ █   
                                                                                          █  



");
            Console.Write("  Input Name:");
            playerName = Console.ReadLine();
            Console.Clear();

            bool raceMenu = true;

            Console.Write($"\n\n  Hi {playerName}!!  I'm an elf.  What are you?");
            do
            {
                Console.WriteLine("\n\n  Choose Your Race:\n1) Human\n2) Elf\n3) Hobgoblin\n4) Orc\n5) Dwarf\n6) Goliath"); //TODO Add Class Descriptions
                ConsoleKey raceChoice = Console.ReadKey(true).Key;
                switch (raceChoice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        playerRace = Race.Human;
                        Console.WriteLine("\n  You're a human?  I've had tons of human friends!!");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        playerRace = Race.Elf;
                        Console.WriteLine("\n  You're and elf like me?!  That's fantastic!");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        playerRace = Race.Hobgoblin;
                        Console.WriteLine("\n  A hobgoblin?  You must be pretty good with magic then.");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        playerRace = Race.Orc;
                        Console.WriteLine("\n  You.... you are an orc?  Please don't club me... ");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        playerRace = Race.Dwarf;
                        Console.WriteLine("\n  A dwarf?  I should've guessed by your small but strong stature.");
                        raceMenu = false;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        playerRace = Race.Goliath;
                        Console.WriteLine("\n  Of course you're a goliath... you're massive.  Just watch your step please.");
                        raceMenu = false;
                        break;
                    default:
                        Console.WriteLine($"\n  {raceChoice} is not a valid option.  Please choose again.");
                        break;
                }//END Race Switch

            } while (raceMenu); //END Do Loop

            Console.WriteLine($"\n\n  {playerName} the {playerRace}!  I need your help...  and seeing \n  as how you're stuck here, you might as well come with me.");
            Console.WriteLine("\n\n  Please press any key to continue...");
            Console.ReadKey(true);


            //Player Creation
            Player player = new Player(playerName, 60, 60, 75, 15, 60, 60, 5, 5, playerRace, starterWeapon, starterArmor, 1, 5, 0);

            //New Title Creation
            Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

            //Starter Enemy
            Monster homunculus = new Monster("Homunculus", 15, 0, 60, 4, 15, 0, 2/*Initiative*/, 4/*strength*/, 0, 4 /*MaxDamage*/ , 5, "A small humanoid, not capable of much harm.", 0, 1 /*TODO MinDamage*/, 0, new Random().Next(1, player.PlayerLevel > 1 ? player.PlayerLevel : 1));

            Console.Clear();

            Console.WriteLine("\n\n  Hey, I need to know if you can fight...\n\n  Let's attack that little guy over there to practice.");
            Console.WriteLine("\n  Press any key to continue...");
            Console.ReadKey(true);

            //TODO - Copy this Monsters array to a later place.
            Monster[] monsters =
                {
                    homunculus
                };

            Monster monster = monsters[new Random().Next(monsters.Length)];
            Console.Write("\n  Do you see it?  It's a ");
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"{monster.Name} " + "!!");
            System.Threading.Thread.Sleep(1500);
            Console.WriteLine("\n\n  Kill it!!!!");
            Console.WriteLine("\n\n  Press any key to continue...");
            Console.ReadKey(true);

            bool exitBattle = false;
            do
            {
                Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("\n\n  You're fighting a " + monster.Name);
                Console.WriteLine("\n\n  Choose an action:\n" +
                   "  A)ttack\n" +
                   "  F)lee\n" +
                   "  V)iew Stats\n" +
                   "  M)onster Stats");
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                Console.Clear();

                switch (userChoice)
                {
                    case ConsoleKey.A:
                        Combat.Battle(player, monster);
                        if (monster.Health <= 0)   //This is where you could add loot drops or add a menu to take a potion.  
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n  You killed the {monster.Name}!!!\n\n  Killing the {monster.Name} earned you {monster.MonsterXp} XP!!!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            player.PlayerXp = player.PlayerXp + monster.MonsterXp;
                            Console.WriteLine("\n  Press any key to continue...");
                            Console.ReadKey(true);
                            exitBattle = true;
                        }
                        break;
                    case ConsoleKey.F:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("  RUN AWAY");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"  The {monster.Name} attacks you as your turn to flee!");
                        Combat.Attack(monster, player);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.V:
                        Console.WriteLine(player);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine(monster);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("  You quit so soon?... Your cowardess saddens me...");
                        exitBattle = true;
                        break;
                    default:
                        Console.WriteLine("  Thou hast choseneth an ivalideth optioneth.");
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }

                if (player.Health < 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine($"  Sorry {player.Name}... You've been slain by the menacing {monster.Name}...\n\n\n\n\n\n\n\n");
                    Console.WriteLine(@" 
                           ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
                          ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                         ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                         ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                         ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                          ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                           ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                           ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                             ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                         ░                  
                                         

");

                    Console.ReadKey(true);
                    exitBattle = true;
                }

            } while (!exitBattle);
            Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

            Console.WriteLine($"  \n\n  That was great {player.Name}!!  Not at all impressive \n  considering your competition, but at least I know \n  you can stab a tiny helpless being to death!!");
            Console.WriteLine($"\n\n  Excuse me for not introducing myself earlier.\n  My name is Snushbat.  I'm looking for some\n  of my friends.  They are all helpless humans.\n  Would you mind helping me find them?\n");

            //Companion creation
            Companion companion = new Companion("Snushbat", 895, 150, 80, 60, 895, 150, 9, 7, 3, 12, player.PlayerLevel, 8, 4, 4);

            Console.WriteLine("\n\n  Of course you will.  You seem quite helpful,\n  and again, there is no way out of here without the help\n  of my friends.\n\n  Don't worry, I can fight too.  I'll show you...\n\n  Let's fight something a bit tougher.");

            Console.Write("\n  Let's get that ");

            Monster caveBear = new Monster("Cave Bear", 65, 0, 4, 4, 65 /*health*/, 0, 4, 6/*strength*/, 0, 8 /*MaxDamage*/, 10, "A small bear cub, with dull claws.", 0, 1 /*TODO MinDamage*/, 0, new Random().Next(1, player.PlayerLevel > 1 ? player.PlayerLevel : 1));
            Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"{caveBear.Name} " + "!!");

            System.Threading.Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n  Press any key to continue...");
            Console.ReadKey(true);

            bool exitBattle2 = false;

            do
            {
                Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("\n\n  You're fighting a " + caveBear.Name);
                Console.WriteLine("\n\n  Choose an action:\n" +
                   "  A)ttack\n" +
                   "  F)lee\n" +
                   "  V)iew Stats\n" +
                   "  M)onster Stats");
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                Console.Clear();

                switch (userChoice)
                {
                    case ConsoleKey.A:
                        Combat.Battle(player, companion, caveBear);
                        if (caveBear.Health <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\n  You killed the {caveBear.Name}!!!\n\n  Killing the {caveBear.Name} earned you {caveBear.MonsterXp} XP!!!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            player.PlayerXp = player.PlayerXp + caveBear.MonsterXp;
                            Console.WriteLine("\n  Press any key to continue...");
                            Console.ReadKey(true);
                            exitBattle2 = true;
                        }
                        break;
                    case ConsoleKey.F:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("RUN AWAY");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"  The {caveBear.Name} attacks you as your turn to flee!");
                        Combat.Attack(monster, player);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.V:
                        Console.WriteLine(player);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine(caveBear);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("\n  You quit so soon?... Your cowardess saddens me...");
                        exitBattle2 = true;
                        break;
                    default:
                        Console.WriteLine("\n  Thou hast choseneth an ivalideth option.");
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }

                if (player.Health < 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine($"  Sorry {player.Name}... You've been slain by the menacing {caveBear.Name}...\n\n\n\n\n\n\n\n");
                    Console.WriteLine(@" 
                           ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
                          ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                         ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                         ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                         ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                          ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                           ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                           ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                             ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                         ░                  
                                         

                 ");

                    Console.ReadKey(true);
                    exitBattle2 = true;
                }

            } while (!exitBattle2);
            Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";


            //Test Sequence, battle with 2 monsters.
            Console.Clear();
            Console.WriteLine("\n\n  See, that wasn't so bad... \n\n  Uh oh, there are more...  GET READY!!");

            System.Threading.Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\n  Press any key to continue...");
            Console.ReadKey(true);

            homunculus.Health = 80;
            caveBear.Health = 10;
            caveBear.Initiative = 90;

            bool exitBattle3 = false;

            do
            {
                Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("\n\n  You're fighting a " + caveBear.Name + " and a " + homunculus.Name);
                Console.WriteLine("\n\n  Choose an action:\n" +
                   "  A)ttack\n" +
                   "  F)lee\n" +
                   "  V)iew Stats\n" +
                   "  M)onster Stats");
                ConsoleKey userChoice = Console.ReadKey(true).Key;

                Console.Clear();

                switch (userChoice)
                {
                    case ConsoleKey.A:
                        Combat.Battle(player, companion, caveBear, homunculus);
                        if (caveBear.Health <= 0 && homunculus.Health <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"  You killed the {caveBear.Name} & the {homunculus.Name}!!!\n\n  You've earned {caveBear.MonsterXp + homunculus.MonsterXp} XP!!!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            player.PlayerXp = player.PlayerXp + caveBear.MonsterXp + homunculus.MonsterXp;
                            Console.WriteLine("\n  Press any key to continue...");
                            Console.ReadKey(true);
                            exitBattle3 = true;
                        }
                        break;
                    case ConsoleKey.F:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine("  RUN AWAY");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"  You are attacked as you as your turn to flee!");
                        Combat.Attack(monster, player);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.V:
                        Console.WriteLine(player);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.M:
                        Console.WriteLine(caveBear);
                        Console.WriteLine("\n");
                        Console.WriteLine(homunculus);
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("\n  You quit so soon?... Your cowardess saddens me...");
                        exitBattle3 = true;
                        break;
                    default:
                        Console.WriteLine("\n  Thou hast choseneth an ivalideth option.");
                        Console.WriteLine("\n  Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                }

                if (player.Health < 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine($"  Sorry {player.Name}... You've been slain by the menacing {caveBear.Name}...\n\n\n\n\n\n\n\n");
                    Console.WriteLine(@" 
                           ▄████  ▄▄▄       ███▄ ▄███▓▓█████     ▒█████   ██▒   █▓▓█████  ██▀███  
                          ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀    ▒██▒  ██▒▓██░   █▒▓█   ▀ ▓██ ▒ ██▒
                         ▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███      ▒██░  ██▒ ▓██  █▒░▒███   ▓██ ░▄█ ▒
                         ░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄    ▒██   ██░  ▒██ █░░▒▓█  ▄ ▒██▀▀█▄  
                         ░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒   ░ ████▓▒░   ▒▀█░  ░▒████▒░██▓ ▒██▒
                          ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░   ░ ▒░▒░▒░    ░ ▐░  ░░ ▒░ ░░ ▒▓ ░▒▓░
                           ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░     ░ ▒ ▒░    ░ ░░   ░ ░  ░  ░▒ ░ ▒░
                           ░ ░   ░   ░   ▒   ░      ░      ░      ░ ░ ░ ▒       ░░     ░     ░░   ░ 
                             ░       ░  ░       ░      ░  ░       ░ ░        ░     ░  ░   ░     
                                                         ░                  
                                         

                 ");

                    Console.ReadKey(true);
                    exitBattle3 = true;
                }

            } while (!exitBattle3);
            Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";


            Console.Clear();
            Console.WriteLine("\n\n  Success!!! Wow, we might have a chance at this after all!!");
            //An ancient elf recruits you to help him reconnect with all his old human friends. 
            //Turns out they have all been dead for centuries and many are the subjects of the epics songs by bards.
            //Comedic when all the bards songs are about dying in the most humiliating ways possible.



        }//END MAIN()

    }//END CLASS

}//END NAMESPACE
