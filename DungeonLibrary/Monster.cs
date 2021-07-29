using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        //fields
        private int _minDamage;
        private int _minMagicDamage;

        //Props
        public int MaxDamage { get; set; }
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
        public Monster(string name, int maxHealth, int maxMana, int hitChance, int armor, int health, int mana, int maxDamage, string description, int maxMagicDamage, int minDamage, int minMagicDamage)
            : base(name, maxHealth, maxMana, hitChance, armor, health, mana)
        {
            Description = description;
            MaxMagicDamage = maxMagicDamage;
            MaxDamage = maxDamage;
            MinMagicDamage = minMagicDamage;
            MinDamage = minDamage;
        }
               
    }//END CLASS

}//END NAMESPACE
