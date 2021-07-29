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
        public Character(string name, int maxHealth, int maxMana, int hitChance, int armor, int health, int mana)
        {
            Name = name;
            MaxHealth = maxHealth;
            MaxMana = maxMana;
            HitChance = hitChance;
            Armor = armor;
            Health = health;
            Mana = mana;
        }//END FQCTOR

        //Methods
        public virtual int CalcArmor()
        {
            return Armor;
        }//END Method CalcArmor
        public virtual int CalcHitChance()
        {
            return HitChance;
        }//END Method CalcHitChance
        public abstract int CalcDamage(); //Method Stub


    }//END CLASS

}//END NAMESPACE
