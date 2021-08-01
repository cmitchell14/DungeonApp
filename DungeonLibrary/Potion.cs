using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Potion : Inventory
    {

        //fields

        //props
        public int HealthPotion { get; set; }
        public int ManaPotion { get; set; }

        //ctors
        public Potion(string name, bool isEquippable, string description, int addHealth, int addMana)
            :base(name, isEquippable, description)
        {
            HealthPotion = addHealth;
            ManaPotion = addMana;
        }

        //methods
        public override string ToString()
        {
            return string.Format($"{Name}\n{Description}");
        }

    }//END CLASS

}//END NAMESPACE
