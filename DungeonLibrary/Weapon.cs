using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Weapon : Inventory
    {

        //fields
        private int _minDamage;

        //props
        public int MaxDamage { get; set; }
        public bool IsTwoHanded { get; set; }
        public int ArmorRank { get; set; }
        public int BonusHitChance { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }
        }

        //ctors
        public Weapon(string name, bool isEquippable, string description, int maxDamage, int minDamage, bool isTwoHanded, int bonusHitChance, int armorRank)
            :base (name, isEquippable, description)
        {
            MaxDamage = maxDamage;
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
            MinDamage = minDamage;
            ArmorRank = armorRank;
        }

        //methods
        public override string ToString()
        {
            return string.Format(base.ToString() + $"Damage: {MinDamage}-{MaxDamage},\nBonus Hit Chance: {BonusHitChance}\n{(IsTwoHanded ? "This weapon is a Two-Handed Weapon." : "You can use this weapon with just one hand.")}");
        }

    }//END CLASS

}//END NAMESPACE
