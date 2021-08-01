using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {

        //fields
        private int _health;
        private int _mana;

        //props
        public string Name { get; set; }
        public int Initiative { get; set; }
        public int Strength { get; set; }
        public int MagicStrength { get; set; }
        public int MaxHealth { get; set; }
        public int MaxMana { get; set; }
        public int HitChance { get; set; }
        public int Armor { get; set; }
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value > MaxHealth ? MaxHealth : value;
            }//END SET Health
        }
        public int Mana
        {
            get { return _mana; }
            set
            {
                _mana = value > MaxMana ? MaxMana : value;
            }//END SET Mana
        }

        //ctors
        //FQCTOR
        public Character(string name, int maxHealth, int maxMana, int hitChance, int armor, int health, int mana, int initiative, int strength, int magicStrength)
        {
            Name = name;
            MaxHealth = maxHealth;
            MaxMana = maxMana;
            HitChance = hitChance;
            Armor = armor;
            Health = health;
            Mana = mana;
            Strength = strength;
            MagicStrength = magicStrength;
            Initiative = Initiative;
        }//END FQCTOR

        //Methods
        public abstract int CalcArmor();

        public abstract int CalcHitChance();

        public abstract int CalcDamage(); //Method Stub


    }//END CLASS

}//END NAMESPACE
