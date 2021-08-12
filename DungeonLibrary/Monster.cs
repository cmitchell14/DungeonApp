using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields
        private int _minDamage;
        private int _minMagicDamage;

        //Props
        public int MaxDamage { get; set; }
        public int MonsterLevel { get; set; }
        public int MonsterXp { get; set; }
        public string Description { get; set; }
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

        //CTORS
        //FQCTOR
        public Monster(string name, int maxHealth, int maxMana, int hitChance, int armor, int health, int mana, int initiative, int strength, int magicStrength, int maxDamage, int monsterXp, string description, int maxMagicDamage, int minDamage, int minMagicDamage, int monsterLevel)
            : base(name, maxHealth, maxMana, hitChance, armor, health, mana, strength, magicStrength, initiative)
        {
            Description = description;
            MonsterXp = monsterXp;
            MaxMagicDamage = maxMagicDamage;
            MaxDamage = maxDamage;
            MinMagicDamage = minMagicDamage;
            MinDamage = minDamage;
            MonsterLevel = monsterLevel;

            switch (MonsterLevel)
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
                    Strength += 4;
                    Armor += 4;
                    Initiative += 4;
                    HitChance += 4;
                    MagicStrength += 4;
                    break;
                case 6:
                    Strength += 5;
                    Armor += 5;
                    Initiative += 6;
                    HitChance += 6;
                    MagicStrength += 5;
                    break;
                case 7:
                    Strength += 8;
                    Armor += 8;
                    Initiative += 6;
                    HitChance += 6;
                    MagicStrength += 8;
                    break;
                case 8:
                    Strength += 10;
                    Armor += 10;
                    Initiative += 7;
                    HitChance += 7;
                    MagicStrength += 10;
                    break;
                case 9:
                    Strength += 12;
                    Armor += 12;
                    Initiative += 8;
                    HitChance += 8;
                    MagicStrength += 12;
                    break;
                case 10:
                    Strength += 13;
                    Armor += 13;
                    Initiative += 9;
                    HitChance += 9;
                    MagicStrength += 13;
                    break;
            }//END SWITCH MonsterLevel

        }//END FQCTOR

        //Methods
        public override string ToString()
        {
            return string.Format($"  Lvl {MonsterLevel} {Name}\n  {Description}\n  {(Health == MaxHealth ? "  It's at Full-Strength" :  Health <= 0 ? "  This creature has perished" : Health <= MaxHealth * .25 ? "  It is nearing death!!" : "  It's losing strength")}");
        }//End ToString()

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage + Strength, MaxDamage + 1 + Strength);
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
