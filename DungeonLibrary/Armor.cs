using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Armor : Inventory
    {

        //fields
       //None Needed

        //props

        public int ArmorRank { get; set; }
        public int BonusHitChance { get; set; }

        //ctor      
        public Armor(string name, bool isEquippable, string description, int armorRank, int bonusHitChance)
            :base (name,isEquippable, description )
        {
            ArmorRank = armorRank;
            BonusHitChance = bonusHitChance;
        }

        //Methods

        public override string ToString()
        {
            return string.Format(base.ToString() + $"\nArmor: {ArmorRank}\n{(BonusHitChance > 0 ? $"Bonus Hit Chance: {BonusHitChance}" : "")}");
        }


    }//END CLASS

}//END NAMESPACE
