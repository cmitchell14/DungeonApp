using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonLibrary
{
    public class Player : Character
    {

        //fields

        //props
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int PlayerLevel { get; set; }
        public int PlayerXp { get; set; }

        //ctors
        public Player(string name, int maxHealth, int maxMana, int hitChance, int armor, int health, int mana, int strength, int magicStrength, Race playerRace, Weapon equippedWeapon, Armor equippedArmor, int playerLevel, int initiative, int playerXp)
            : base(name, maxHealth, maxMana, hitChance, armor, health, mana, strength, magicStrength, initiative)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;
            EquippedArmor = equippedArmor;
            PlayerLevel = playerLevel;
            PlayerXp = PlayerXp;


            switch (PlayerRace)
            {
                case Race.Human:
                    MaxMana -= 10;
                    Mana -= 10;
                    EquippedWeapon.MinDamage += 2;
                    MaxHealth += 3;
                    Health += 3;
                    Armor += 5;
                    break;
                case Race.Elf:
                    HitChance += 7;
                    MaxHealth -= 5;
                    Health -= 5;
                    Initiative = +3;
                    MaxMana -= 5;
                    Mana -= 5;
                    break;
                case Race.Hobgoblin:
                    MaxHealth -= 15;
                    Health -= 15;
                    MaxMana += 27;
                    Mana += 27;
                    HitChance -= 7;
                    Armor -= 5;
                    Initiative += 2;
                    break;
                case Race.Orc:
                    MaxHealth += 15;
                    Health += 15;
                    MaxMana -= 40;
                    Mana -= 40;
                    EquippedWeapon.MinDamage += 5;
                    EquippedWeapon.MaxDamage += 4;
                    Armor += 12;
                    Initiative -= 5;
                    break;
                case Race.Dwarf:
                    Initiative -= 3;
                    MaxHealth += 10;
                    Health += 10;
                    Armor += 7;
                    MaxMana = 0;
                    Mana = 0;
                    break;
                case Race.Goliath:
                    MaxMana = 0;
                    Mana = 0;
                    MaxHealth += 30;
                    Health += 30;
                    EquippedWeapon.MinDamage += 8;
                    EquippedWeapon.MaxDamage += 6;
                    Initiative -= 9;
                    Armor += 12;
                    break;
                default:
                    break;
            }//END PlayerRace Switch

            switch (PlayerLevel)
            {
                case 1:

                    break;
                case 2:
                    Strength += 1;
                    Armor += 1;
                    Initiative += 1;
                    HitChance += 1;
                    MagicStrength += 1;
                    break;
                case 3:
                    Strength += 2;
                    Armor += 2;
                    Initiative += 2;
                    HitChance += 2;
                    MagicStrength += 2;
                    break;
                case 4:
                    Strength += 3;
                    Armor += 3;
                    Initiative += 3;
                    HitChance += 3;
                    MagicStrength += 3;
                    break;
                case 5:
                    Strength += 5;
                    Armor += 5;
                    Initiative += 5;
                    HitChance += 5;
                    MagicStrength += 5;
                    break;
                case 6:
                    Strength += 7;
                    Armor += 7;
                    Initiative += 8;
                    HitChance += 8;
                    MagicStrength += 7;
                    break;
                case 7:
                    Strength += 10;
                    Armor += 10;
                    Initiative += 8;
                    HitChance += 8;
                    MagicStrength += 10;
                    break;
                case 8:
                    Strength += 13;
                    Armor += 13;
                    Initiative += 9;
                    HitChance += 9;
                    MagicStrength += 13;
                    break;
                case 9:
                    Strength += 16;
                    Armor += 16;
                    Initiative += 10;
                    HitChance += 10;
                    MagicStrength += 16;
                    break;
                case 10:
                    Strength += 20;
                    Armor += 20;
                    Initiative += 12;
                    HitChance += 12;
                    MagicStrength += 20;
                    break;

            }//END PlayerLevel Switch

        }//END FQCTOR

        //methods
        public override string ToString()
        {
            return string.Format($"  Name: {Name} the {PlayerRace}\n  HP: {Health}/{MaxHealth}     Mana: {Mana}/{MaxMana}\n  Equipped Weapon: {EquippedWeapon}\n  Equipped Armor: {EquippedArmor}\n  Overall Armor Rating: {Armor}\n  Hit Chance: {HitChance}");
        }//END ToString()

        public override int CalcArmor()
        {
            return new Random().Next(Armor + EquippedArmor.ArmorRank + EquippedWeapon.ArmorRank - 5, Armor + EquippedArmor.ArmorRank + EquippedWeapon.ArmorRank +1);
        }//END CalcArmor()

        public override int CalcDamage()
        {
            return new Random().Next(Strength +  EquippedWeapon.MinDamage, Strength + EquippedWeapon.MaxDamage + 1);
        }//END CalcDamage()
        public override int CalcHitChance()
        {
            return new Random().Next(HitChance + EquippedWeapon.BonusHitChance + EquippedArmor.BonusHitChance - 4, HitChance + EquippedWeapon.BonusHitChance + EquippedArmor.BonusHitChance + 1);
        }//END CalcHitChance()



    }//END CLASS

}//END NAMESPACE
