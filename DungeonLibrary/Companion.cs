using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonLibrary
{
    public class Companion : Character
    {

        //fields
        private int _minDamage;
        private int _minMagicDamage;

        //Props
        public int MaxDamage { get; set; }
        public int PlayerLevel { get; set; }
        public int MaxMagicDamage { get; set; }
        public int MinMagicDamage
        {
            get { return _minMagicDamage; }
            set
            {
                _minMagicDamage = value > 0 && value <= MaxMagicDamage ? value : 1;
            }//END set
        }//END MinMagicDamage Prop
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//END set
        }///END MinDamage Prop

        //CTOR

        public Companion(string name, int maxHealth, int maxMana, int hitChance, int armor, int health, int mana, int initiative, int strength, int magicStrength, int maxDamage, int playerLevel, int maxMagicDamage, int minMagicDamage, int minDamage)
            : base(name, maxHealth, maxMana, hitChance, armor, health, mana, initiative, strength, magicStrength)
        {
            MaxDamage = maxDamage;
            PlayerLevel = playerLevel;
            MaxMagicDamage = maxMagicDamage;
            MinMagicDamage = minMagicDamage;
            MinDamage = minDamage;

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
            }//END SWITCH PlayerLevel

        }//END FQCTOR

        //Methods
        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//END CalcDamage()

        public override int CalcHitChance()
        {
            return new Random().Next(HitChance - 2, HitChance + 1);
        }//END CalcHitChance()

        public override int CalcArmor()
        {
            return new Random().Next(Armor - 4, Armor + 1);
        }//END CalcArmor()





    }//END CLASS

}//END NAMESPACE
