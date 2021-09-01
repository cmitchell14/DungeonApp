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
            Armor starterArmor = new Armor("Rags", true, "  Literally a wash rag thrown over your shoulder...\n  more likely to make you sick than block a blow.", 1, 0);
            Potion healthPotion = new Potion("Health Potion", false, "Replenishes Health", 2, 50, 0);
            Potion manaPotion = new Potion("Mana Potion", false, "Replenishes Mana", 2, 0, 50);


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
            Console.WriteLine("\n  Welcome to Grimlandia.  Your situation is bleak, as you find yourself\n  in a cave hungry, wet, and bruised.  You're unsure of \n  how you came to be in this place. As your eyes adjust to the dark, you see\n  a small humanoid walking up to you...");

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
            Companion companion = new Companion("Snushbat", 895, 150, 80, 60, 895, 150, 9, 7, 3, 12, player.PlayerLevel, 8, 4, 4);

            //New Title Creation
            Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

            //Starter Enemy
            Monster homunculus = new Monster("Homunculus", 15, 0, 60, 4, 15, 0, 2/*Initiative*/, 4/*strength*/, 0, 4 /*MaxDamage*/ , 5, "A small humanoid, not capable of much harm.", 0, 1 /*TODO MinDamage*/, 0, new Random().Next(1, player.PlayerLevel > 1 ? player.PlayerLevel : 1));

            Console.Clear();

            Console.WriteLine("\n\n  Hey, I need to know if you can fight...\n\n  Let's attack that little guy over there to practice.");
            Console.WriteLine("\n  Press any key to continue...");
            Console.ReadKey(true);

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
            while (!exitBattle)
            {
                Console.Title = $" {player.Name} the {player.PlayerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

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
                        Console.WriteLine($"  The {monster.Name} attacks you as your turn to flee, but you can't get away!");
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
                    Console.WriteLine("Okay... that was sad... you nearly died to a little Homunculus...\n  Good thing I was here to save you...");

                    Console.ReadKey(true);
                    exitBattle = true;
                }

            }
            Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

            Console.WriteLine($"  \n\n  Not at all impressive {player.Name}, \n  considering your competition, but at least I know \n  you can stab a tiny helpless being to death!!");

            //START OF INTRO LOOP -- YOU CAN DIE NOW -- =======================================================================
            bool introLoop = false;
            do
            {
                bool exitBattle2 = false;

                Console.WriteLine($"\n\n  Excuse me for not introducing myself earlier.\n  My name is Snushbat.  I'm looking for some\n  of my friends.  They are all helpless humans.\n  Would you mind helping me find them?\n");

                //Companion creation
                Console.WriteLine("\n\n  Of course you will.  You seem quite helpful,\n  and again, there is no way out of here without the help\n  of my friends.\n\n  Don't worry, I can fight too.  I'll show you...\n\n  Let's fight something a bit tougher.");

                Console.Write("\n  Let's get that ");

                Monster caveBear = new Monster("Cave Bear", 65, 0, 4, 4, 65 /*health*/, 0, 4, 6/*strength*/, 0, 8 /*MaxDamage*/, 10, "A small bear cub, with dull claws.", 0, 1 /*TODO MinDamage*/, 0, new Random().Next(1, player.PlayerLevel > 1 ? player.PlayerLevel : 1));
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine($"{caveBear.Name} " + "!!");

                System.Threading.Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n\n  Press any key to continue...");
                Console.ReadKey(true);



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

                homunculus.Health = 15;
                caveBear.Health = 35;

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
                        //TODO -- ADD RESTARTPROGRAM() HERE ======================
                        Console.ReadKey(true);
                        exitBattle3 = true;
                    }

                } while (!exitBattle3);
                Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";


                Console.Clear();
                Console.WriteLine("\n\n  Success!!! Wow, we might have a chance at this after all!!");

                Console.WriteLine("\n  Oh, and one last thing before we really get going. \n  Here are a few potions for you.  I picked them up\n  from that Homunculus back there.  Creatures drop\n  all sorts of great stuff.  Just keep an eye out.\n\n");
                Console.WriteLine("  Press any key to continue.");
                Console.ReadKey(true);
                Console.Clear();

                Console.WriteLine($"  You've acquired 2 {healthPotion.Name}s, and 2 {manaPotion.Name}s!!\n\n");

                Console.WriteLine($"  So I was saying, before we were rudely attacked by those mindless creatures,\n  that I need your help finding my friends.  I've been searching for quite some time now, and\n  I'm sure I'm on the right track.  I just need a little bit of help navigating this cave.\n  Will you help me {player.Name}?");

                bool choiceExit = false;
                do
                {
                    Console.WriteLine("\n\n  Will you help Snushbat?:  Y)es or N)o");
                    ConsoleKey helpChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (helpChoice)
                    {
                        case ConsoleKey.Y:
                            Console.WriteLine($"  That's Great {player.Name}!!  I knew when we met last night at the pub\n\n  and I knocked you out and brought you here that it would be worth it!!");
                            choiceExit = true;
                            introLoop = true;
                            break;
                        case ConsoleKey.N:
                            Console.WriteLine($"  Uh, are you sure about that {player.Name}?  If you don't help, I'll be forced\n  to engage you in fisticuffs... I'm a lot stronger than you.\n\n");
                            Console.WriteLine($"  Last chance {player.Name}... will you help me?");
                            Console.Write("  Y)es or N)o:");
                            ConsoleKey helpChoice2 = Console.ReadKey(true).Key;
                            Console.Clear();
                            switch (helpChoice2)
                            {
                                case ConsoleKey.Y:

                                    choiceExit = true;
                                    introLoop = true;
                                    break;
                                case ConsoleKey.N:
                                    Console.WriteLine($"  Okay {player.Name}... You asked for it");
                                    bool exitBattle4 = false;
                                    do
                                    {
                                        Monster snushBat = new Monster("Snushbat", 298, 75, 90, 65, 298, 75, 452, 25, 25, 20, 185, "Could've been your friend... now about to kill you.", 45, 18, 40, player.PlayerLevel);
                                        Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.Clear();
                                        Console.WriteLine("\n\n  You're fighting " + snushBat.Name);
                                        Console.WriteLine("\n\n  Choose an action:\n" +
                                           "  A)ttack\n" +
                                           "  U)se Potion\n" +
                                           "  F)lee\n" +
                                           "  V)iew Stats\n" +
                                           "  M)onster Stats\n");

                                        ConsoleKey userChoice = Console.ReadKey(true).Key;

                                        Console.Clear();


                                        switch (userChoice)
                                        {

                                            case ConsoleKey.A:
                                                Combat.Battle(player, snushBat);
                                                if (snushBat.Health <= 0)
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine($"  You killed {snushBat.Name}!!!\n\n  You've earned {snushBat.MonsterXp}  XP!!!");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    player.PlayerXp = player.PlayerXp + snushBat.MonsterXp;
                                                    Console.WriteLine("\n  Press any key to continue...");
                                                    Console.ReadKey(true);
                                                    introLoop = true;
                                                    exitBattle4 = true;
                                                    choiceExit = true;
                                                }
                                                break;
                                            case ConsoleKey.F:
                                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                                Console.BackgroundColor = ConsoleColor.White;
                                                Console.Clear();
                                                Console.WriteLine("  RUN AWAY");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                Console.WriteLine($"  You are attacked as you as your turn to flee, but you can't escape!!!");
                                                Combat.Attack(monster, player);
                                                Console.WriteLine("\n  Press any key to continue...");
                                                Console.ReadKey(true);
                                                break;
                                            case ConsoleKey.U:
                                                Console.WriteLine("  Choose a potion to use:");
                                                Console.WriteLine($"  1) {healthPotion.Name} - You have {healthPotion.Quantity} remaining");
                                                Console.WriteLine($"  2) {manaPotion.Name} - You have {manaPotion.Quantity} remaining");
                                                ConsoleKey potionChoice = Console.ReadKey(true).Key;
                                                switch (potionChoice)
                                                {
                                                    case ConsoleKey.D1:
                                                    case ConsoleKey.NumPad1:
                                                        if (healthPotion.Quantity > 0)
                                                        {
                                                            Potion.UseHealthPotion(player, healthPotion);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("  You don't have any.");
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("  Please choose a valid option.");
                                                        break;
                                                    case ConsoleKey.D2:
                                                    case ConsoleKey.NumPad2:
                                                        if (manaPotion.Quantity > 0)
                                                        {
                                                            Potion.UseManaPotion(player, manaPotion);
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("  You don't have any.");
                                                        }
                                                        break;
                                                }
                                                break;

                                            case ConsoleKey.V:
                                                Console.WriteLine(player);
                                                Console.WriteLine("\n  Press any key to continue...");
                                                Console.ReadKey(true);
                                                break;
                                            case ConsoleKey.M:
                                                Console.WriteLine(snushBat);
                                                Console.WriteLine("\n  Press any key to continue...");
                                                Console.ReadKey(true);
                                                break;
                                            case ConsoleKey.Escape:
                                                Console.WriteLine("\n  You quit so soon?... Your cowardess saddens me...");
                                                exitBattle4 = true;
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
                                            Console.WriteLine($"  Sorry {player.Name}... You've been slain by the menacing {snushBat.Name}...\n\n\n\n\n\n\n\n");
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
                                            exitBattle4 = true;
                                            choiceExit = true;
                                        }

                                    } while (!exitBattle4);
                                    Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";
                                    break;
                                default:
                                    Console.WriteLine("  Answer yes or no.... ");
                                    break;
                            }
                            break;
                        default:
                            Console.WriteLine($"{player.Name}, it's a simple yes or no question... Please choose again.");
                            break;
                    }
                } while (!choiceExit);
            } while (!introLoop);
            //================================================ END FIRST/INTRO LOOP ========================================================

            Console.Clear();

            //=========================================== FIRST LEVEL LOOP =================================================================

            //LEVEL ONE VARIABLES-------------------
            Weapon shortSword = new Weapon("Short Sword", true, "A basic short sword.  You can stab people with it.\n  You could even slash someone with it.", 17, 11, false, 2, 0);
            Armor leatherArmor = new Armor("Leather Body Armor", true, "  Basic Leather Body Armor", 22, 0);
            Monster zombie = new Monster("Zombie", 42, 0, 73, 10, 42, 0, 6, 8, 0, 12, 12, "An undead zombie, as made famous by the TV show \"The Walking Dead\".", 0, 5, 0, player.PlayerLevel);
            Monster gargoyle = new Monster("Gargoyle", 50, 0, 85, 12, 50, 0, 9, 7, 0, 13, 15, "A grotesque monstrosity set to protect a location and the people therein", 0, 7, 0, player.PlayerLevel);
            Monster orc = new Monster("Orc", 52, 0, 53, 14, 52, 0, 4, 14, 0, 16, 17, "A large humanoid that is good at using clubs to hit you in the face.", 0, 6, 0, player.PlayerLevel);
            Monster goblin = new Monster("Goblin", 22, 30, 64, 2, 22, 64, 5, 3, 0, 9, 11, "Small and grotesque, mischievous and outright malicious. They are greedy, especially for gold and jewelry.", 0, 2, 0, player.PlayerLevel);
            Monster troll = new Monster("Troll", 47, 0, 57, 15, 47, 0, 2, 13, 0, 17, 23, "Trolls are ugly... like really ugly.  Inside and out.", 0, 7, 0, player.PlayerLevel);
            Monster imp = new Monster("Imp", 16, 0, 48, 3, 16, 0, 9, 1, 0, 6, 8, "Pathetic little creatures that always try to fight you...\n  they rarely win and will be extinct soon.", 0, 1, 0, player.PlayerLevel);

            //Level One Monster Array ===========================================
            Monster[] levelOneMonsters =
                {
                    zombie, gargoyle, orc
                };
            Monster[] levelOneMonsters2 =
                {
                    goblin, troll, imp
                };

            bool levelOneLoop = false;

            while (!levelOneLoop)
            {
                if (player.Health <= 0)
                {
                    player.Health = 20;
                    healthPotion.Quantity = healthPotion.Quantity + 1;
                }
                while (player.Health > 0)
                {
                    Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";
                    Console.Clear();
                    Console.WriteLine($"  That's Great {player.Name}!!  I knew when we met last night at the pub\n\n  and I knocked you out and brought you here that it would be worth it!!");
                    Console.WriteLine("\n\n  Snushbat: Now that you are my partner, and not an unwilling captor,\n  let's find my friends!!!\n  Let's head down this hallway.  Last time I was here I couldn't\n  make it past the second room.  I'll let you take the lead.");
                    Console.Write("  Press any key to continue...");
                    Console.ReadKey(true);
                    Console.Clear();
                    Console.WriteLine("  You start walking down a dark hallway.  After Walking for a bit\n  you come to an intersection.  There are rooms to the left and right.\n  You can also proceed forward.");
                    bool directionLoop = false;
                    do
                    {
                        Console.Write("\n\n  Which way would you like to go?\n\n  F)orward\n  L)eft\n  R)ight");
                        ConsoleKey directionChoice = Console.ReadKey(true).Key;
                        switch (directionChoice)
                        {
//  ================================================ IF YOU CHOOSE TO GO FORWARD================================================================
                            case ConsoleKey.F:
                                directionLoop = true;
                                break;
//  ================================================ IF YOU CHOOSE TO GO LEFT ================================================================
                            case ConsoleKey.L:
                                Console.Clear();
                                Console.WriteLine("  You enter the room on the left, and see 3 treasure chests.\n  What would you like to do?");
                                bool treasureRoom = false;
                                bool treasureRoom2 = false;
                                bool treasureRoom3 = false;
                                bool treasureRoom4 = false;
                                bool treasureRoom5 = false;
                                bool treasureRoom6 = false;
                                bool treasureRoom7 = false;
                                bool beenLeft = false;
                                bool beenRight = false;
                                bool beenMid = false;
                                bool treasureRoomLoop = false;
                                do
                                {
                                    if (beenLeft && !beenRight && !beenMid)
                                    {
                                        while (!treasureRoom)
                                        {
                                            Console.WriteLine("\n\n  2) Open the chest in the middle\n  3) Open the chest on the right\n  4) Leave the room");
                                            ConsoleKey treasures = Console.ReadKey(true).Key;

                                            switch (treasures)
                                            {
                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Leather Body Armor");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip2 = false;
                                                    while (!equip2)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Armor: {player.EquippedArmor}\n  Found Item: {leatherArmor}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to equip this item?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedArmor = leatherArmor;
                                                                equip2 = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Leather Body Armor");
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                beenMid = true;
                                                                treasureRoom = true;
                                                                System.Threading.Thread.Sleep(2000);
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip2 = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP ARMOR LOOP

                                                    break;
                                                case ConsoleKey.D3:
                                                case ConsoleKey.NumPad3:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("3 Health Potions");
                                                    healthPotion.Quantity = healthPotion.Quantity + 3;
                                                    beenRight = true;
                                                    treasureRoom = true;
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    break;
                                                case ConsoleKey.D4:
                                                case ConsoleKey.NumPad4:
                                                    Console.WriteLine("  You turn around, and leave the room...");
                                                    treasureRoom = true;
                                                    treasureRoomLoop = true;
                                                    System.Threading.Thread.Sleep(2000);
                                                    break;
                                                default:
                                                    treasureRoom = true;
                                                    Console.WriteLine("You can't do that.");
                                                    break;
                                            }
                                        }//END TREASURE ROOM LOOP beenLEFT
                                    }//END IF beenLEFT
                                    else if (beenRight && !beenLeft && !beenMid)
                                    {
                                        while (!treasureRoom2)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n\n  1) Open chest on the left\n  2) Open the chest in the middle\n  4) Leave the room");
                                            ConsoleKey treasures = Console.ReadKey(true).Key;

                                            switch (treasures)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find a ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Short Sword");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip = false;
                                                    while (!equip)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Weapon: {player.EquippedWeapon}\n  Found Item: {shortSword}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to use this weapon?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedWeapon = shortSword;
                                                                equip = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Short Sword");
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                beenLeft = true;
                                                                treasureRoom2 = true;
                                                                System.Threading.Thread.Sleep(2000);
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP WEAPON LOOP
                                                    break;
                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Leather Body Armor");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip2 = false;
                                                    while (!equip2)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Armor: {player.EquippedArmor}\n  Found Item: {leatherArmor}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to equip this item?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedArmor = leatherArmor;
                                                                equip2 = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Leather Body Armor");
                                                                beenMid = true;
                                                                treasureRoom2 = true;
                                                                System.Threading.Thread.Sleep(2000);
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip2 = true;
                                                                treasureRoom2 = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP ARMOR LOOP

                                                    break;
                                            }
                                        }//END TREASURE ROOM LOOP with ALL
                                    }//END IF beenRIGHT
                                    else if (beenMid && !beenLeft && !beenRight)
                                    {
                                        while (!treasureRoom3)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n\n  1) Open chest on the left\n  3)  Open the chest on the right\n  4) Leave the room");
                                            ConsoleKey treasures = Console.ReadKey(true).Key;

                                            switch (treasures)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find a ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Short Sword");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip = false;
                                                    while (!equip)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Weapon: {player.EquippedWeapon}\n  Found Item: {shortSword}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to use this weapon?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedWeapon = shortSword;
                                                                equip = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Short Sword");
                                                                beenLeft = true;
                                                                treasureRoom3 = true;
                                                                System.Threading.Thread.Sleep(2000);
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP WEAPON LOOP
                                                    break;
                                                case ConsoleKey.D3:
                                                case ConsoleKey.NumPad3:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("3 Health Potions");
                                                    healthPotion.Quantity = healthPotion.Quantity + 3;
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    beenRight = true;
                                                    treasureRoom3 = true;
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    break;
                                                case ConsoleKey.D4:
                                                case ConsoleKey.NumPad4:
                                                    Console.WriteLine("  You turn around, and leave the room...");
                                                    System.Threading.Thread.Sleep(2000);
                                                    treasureRoom3 = true;
                                                    treasureRoomLoop = true;
                                                    break;
                                                default:
                                                    treasureRoom3 = true;
                                                    break;
                                            }
                                        }//END TREASURE ROOM LOOP with ALL
                                    }//END IF beenMID
                                    else if (beenLeft && beenMid && !beenRight)
                                    {
                                        while (!treasureRoom4)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n\n  3) Open the chest on the right\n  4) Leave the room");
                                            ConsoleKey treasures = Console.ReadKey(true).Key;

                                            switch (treasures)
                                            {
                                                case ConsoleKey.D3:
                                                case ConsoleKey.NumPad3:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("3 Health Potions");
                                                    healthPotion.Quantity = healthPotion.Quantity + 3;
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    beenRight = true;
                                                    treasureRoom4 = true;
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    break;
                                                case ConsoleKey.D4:
                                                case ConsoleKey.NumPad4:
                                                    Console.WriteLine("  You turn around, and leave the room...");
                                                    treasureRoom4 = true;
                                                    treasureRoomLoop = true;
                                                    break;
                                                default:
                                                    treasureRoom4 = true;
                                                    break;
                                            }
                                        }//END TREASURE ROOM LOOP with ALL
                                    }//END beenLEFT & beenMID
                                    else if (beenLeft && beenRight && !beenMid)
                                    {
                                        while (!treasureRoom5)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n\n  2) Open the chest in the middle\n  4) Leave the room");
                                            ConsoleKey treasures = Console.ReadKey(true).Key;

                                            switch (treasures)
                                            {
                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Leather Body Armor");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip2 = false;
                                                    while (!equip2)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Armor: {player.EquippedArmor}\n  Found Item: {leatherArmor}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to equip this item?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedArmor = leatherArmor;
                                                                equip2 = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Leather Body Armor");
                                                                beenMid = true;
                                                                treasureRoom5 = true;
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                System.Threading.Thread.Sleep(2000);
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip2 = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP ARMOR LOOP

                                                    break;
                                                case ConsoleKey.D4:
                                                case ConsoleKey.NumPad4:
                                                    Console.WriteLine("  You turn around, and leave the room...");
                                                    treasureRoom5 = true;
                                                    treasureRoomLoop = true;
                                                    break;
                                                default:
                                                    treasureRoom5 = true;
                                                    break;
                                            }
                                        }//END TREASURE ROOM LOOP with ALL
                                    }//END IF beenLEFT & beenRIGHT
                                    else if (beenRight && beenMid && !beenLeft)
                                    {
                                        while (!treasureRoom6)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n\n  1) Open chest on the left\n  4) Leave the room");
                                            ConsoleKey treasures = Console.ReadKey(true).Key;

                                            switch (treasures)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find a ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Short Sword");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip = false;
                                                    while (!equip)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Weapon: {player.EquippedWeapon}\n  Found Item: {shortSword}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to use this weapon?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedWeapon = shortSword;
                                                                equip = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Short Sword");
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                beenLeft = true;
                                                                treasureRoom6 = true;
                                                                System.Threading.Thread.Sleep(2000);
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP WEAPON LOOP
                                                    break;
                                                case ConsoleKey.D4:
                                                case ConsoleKey.NumPad4:
                                                    Console.WriteLine("  You turn around, and leave the room...");
                                                    treasureRoom6 = true;
                                                    treasureRoomLoop = true;
                                                    break;
                                                default:
                                                    treasureRoom6 = true;
                                                    break;
                                            }
                                        }//END TREASURE ROOM LOOP with ALL
                                    }//END IF beenRIGTH & beenMID
                                    else if (beenRight && beenLeft && beenMid)
                                    {
                                        treasureRoom = true;
                                        treasureRoomLoop = true;
                                        Console.WriteLine("  All the chests are empty.  You turn around and leave the room.");
                                        System.Threading.Thread.Sleep(2000);
                                    }
                                    else
                                    {
                                        while (!treasureRoom7)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("\n\n  1) Open chest on the left\n  2) Open the chest in the middle\n  3) Open the chest on the right\n  4) Leave the room");
                                            ConsoleKey treasures = Console.ReadKey(true).Key;

                                            switch (treasures)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find a ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Short Sword");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip = false;
                                                    while (!equip)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Weapon: {player.EquippedWeapon}\n  Found Item: {shortSword}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to use this weapon?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedWeapon = shortSword;
                                                                equip = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Short Sword");
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                beenLeft = true;
                                                                treasureRoom7 = true;
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("  You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP WEAPON LOOP
                                                    break;
                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("Leather Body Armor");
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    bool equip2 = false;
                                                    while (!equip2)
                                                    {

                                                        Console.Clear();
                                                        Console.WriteLine($"\n\n  Current Armor: {player.EquippedArmor}\n  Found Item: {leatherArmor}");
                                                        System.Threading.Thread.Sleep(3000);
                                                        Console.WriteLine("\n\n  Would you like to equip this item?  Y)es or N)o");
                                                        ConsoleKey equipChoice = Console.ReadKey(true).Key;
                                                        switch (equipChoice)
                                                        {
                                                            case ConsoleKey.Y:
                                                                player.EquippedArmor = leatherArmor;
                                                                equip2 = true;
                                                                Console.Write("\n\n  You have equipped the ");
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.Write("Leather Body Armor");
                                                                Console.ForegroundColor = ConsoleColor.Black;
                                                                beenMid = true;
                                                                treasureRoom7 = true;
                                                                break;
                                                            case ConsoleKey.N:
                                                                equip2 = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("  You can't do that.");
                                                                break;
                                                        }
                                                    }//END EQUIP ARMOR LOOP

                                                    break;
                                                case ConsoleKey.D3:
                                                case ConsoleKey.NumPad3:
                                                    Console.Clear();
                                                    Console.Write("\n\n  You open the chest and find ");
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.Write("3 Health Potions");
                                                    healthPotion.Quantity = healthPotion.Quantity + 3;
                                                    Console.ForegroundColor = ConsoleColor.Black;
                                                    beenRight = true;
                                                    treasureRoom7 = true;
                                                    Console.Write("!");
                                                    Console.WriteLine("\n\n  Press any key to continue..");
                                                    Console.ReadKey(true);
                                                    break;
                                                case ConsoleKey.D4:
                                                case ConsoleKey.NumPad4:
                                                    Console.WriteLine("  You turn around, and leave the room...");
                                                    treasureRoom7 = true;
                                                    treasureRoomLoop = true;
                                                    break;
                                                default:
                                                    treasureRoom7 = true;
                                                    Console.WriteLine("  You can't do that.");
                                                    break;
                                            }
                                        }//END TREASURE ROOM LOOP with ALL
                                    }//END IF NOT BEEN IN ANY ROOM
                                } while (!treasureRoomLoop);
                                break;                           
//  ================================================ END OF GO LEFT ==================================================================
//  ================================================ IF YOU CHOOSE TO GO RIGHT =======================================================
                            case ConsoleKey.R:
                                Console.Clear();
                                Console.WriteLine("\n\n  You enter the room and find a bunch of monsters!!!");
                                Monster monsterOne = levelOneMonsters[new Random().Next(0, levelOneMonsters.Length)];
                                Monster monsterTwo = levelOneMonsters2[new Random().Next(0, levelOneMonsters2.Length)];
                                monsterOne.Health = monsterOne.MaxHealth;
                                monsterTwo.Health = monsterTwo.MaxHealth;
                                System.Threading.Thread.Sleep(2500);
                                bool exitBattle4 = false;
                                do
                                {
                                    

                                    Console.Title = $" {player.Name} the {playerRace}   HP: {player.Health}/{player.MaxHealth}  MP: {player.Mana}/{player.MaxMana}                           {gameTitle}                             Player Level: {player.PlayerLevel}    XP: {player.PlayerXp}";

                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    Console.WriteLine("\n\n  You're fighting a " + monsterOne.Name + " and a " + monsterTwo.Name + ".");
                                    Console.WriteLine("\n\n  Choose an action:\n" +
                                       "  A)ttack\n" +
                                       "  U)se Potion\n" +
                                       "  F)lee\n" +
                                       "  V)iew Stats\n" +
                                       "  M)onster Stats\n");

                                    ConsoleKey userChoice = Console.ReadKey(true).Key;

                                    Console.Clear();


                                    switch (userChoice)
                                    {
                                        
                                        case ConsoleKey.A:
                                            Combat.Battle(player, companion, monsterOne, monsterTwo);
                                            if (monsterOne.Health <= 0 && monsterTwo.Health <= 0)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine($"  You defeated the {monsterOne.Name} and the {monsterTwo.Name}!!!\n\n  You've earned {monsterOne.MonsterXp + monsterTwo.MonsterXp}  XP!!!");
                                                Console.ForegroundColor = ConsoleColor.Black;
                                                player.PlayerXp = player.PlayerXp + monsterOne.MonsterXp + monsterTwo.MonsterXp;
                                                Console.WriteLine("\n  Press any key to continue...");
                                                Console.ReadKey(true);
                                                exitBattle4 = true;
                                            }
                                            break;
                                        case ConsoleKey.F:
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.BackgroundColor = ConsoleColor.White;
                                            Console.Clear();
                                            Console.WriteLine("  RUN AWAY");
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine($"  You are attacked as you as your turn to flee, but you can't escape!!!");
                                            Combat.Attack(monster, player);
                                            Console.WriteLine("\n  Press any key to continue...");
                                            Console.ReadKey(true);
                                            break;
                                        case ConsoleKey.U:
                                            Console.WriteLine("  Choose a potion to use:");
                                            Console.WriteLine($"  1) {healthPotion.Name} - You have {healthPotion.Quantity} remaining");
                                            Console.WriteLine($"  2) {manaPotion.Name} - You have {manaPotion.Quantity} remaining");
                                            ConsoleKey potionChoice = Console.ReadKey(true).Key;
                                            switch (potionChoice)
                                            {
                                                case ConsoleKey.D1:
                                                case ConsoleKey.NumPad1:
                                                    if (healthPotion.Quantity > 0)
                                                    {
                                                        Potion.UseHealthPotion(player, healthPotion);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("  You don't have any.");
                                                    }
                                                    break;
                                                default:
                                                    Console.WriteLine("  Please choose a valid option.");
                                                    break;
                                                case ConsoleKey.D2:
                                                case ConsoleKey.NumPad2:
                                                    if (manaPotion.Quantity > 0)
                                                    {
                                                        Potion.UseManaPotion(player, manaPotion);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("  You don't have any.");
                                                    }
                                                    break;
                                            }
                                            break;

                                        case ConsoleKey.V:
                                            Console.WriteLine(player);
                                            Console.WriteLine("\n  Press any key to continue...");
                                            Console.ReadKey(true);
                                            break;
                                        case ConsoleKey.M:
                                            Console.WriteLine(monsterOne);
                                            Console.WriteLine(monsterTwo);
                                            Console.WriteLine("\n  Press any key to continue...");
                                            Console.ReadKey(true);
                                            break;
                                        case ConsoleKey.Escape:
                                            Console.WriteLine("\n  You quit so soon?... Your cowardess saddens me...");
                                            exitBattle4 = true;
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
                                        Console.WriteLine($"  Sorry {player.Name}... You've been slain...\n\n\n\n\n\n\n\n");
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
                                        exitBattle4 = true;
                                        System.Threading.Thread.Sleep(3500);
                                        Console.WriteLine("\n\n  Press any key to continue...");
                                        directionLoop = true;
                                        Console.ReadKey(true);
                                    }

                                } while (!exitBattle4);
                                break;
                            default:
                                Console.WriteLine("\n\n  You can't go that way... Please choose again.");
                                break;
//  ================================================ END OF GO RIGHT =================================================================

                        }//END SWITCH DIRECTION CHOICE
                    } while (!directionLoop); //END FIRST DIRECTION CHOICE
                    Console.Clear();
                    Console.WriteLine("  You proceed down the hallway.  ");


                }//END LOOP IF PLAYER DIES
            }//END OF LEVELONELOOP

            //An ancient elf recruits you to help him reconnect with all his old human friends. 
            //Turns out they have all been dead for centuries and many are the subjects of the epics songs by bards.
            //Comedic when all the bards songs are about dying in the most humiliating ways possible.

        }//END MAIN()

    }//END CLASS

}//END NAMESPACE
