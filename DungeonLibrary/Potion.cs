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
        public int Quantity { get; set; }

        //ctors
        public Potion(string name, bool isEquippable, string description, int quantity, int addHealth, int addMana)
            :base(name, isEquippable, description)
        {
            HealthPotion = addHealth;
            ManaPotion = addMana;
            Quantity = quantity;
        }

        //methods
        public override string ToString()
        {
            return string.Format($"{Name}\n{Description}");
        }

        public static void UseHealthPotion(Player player, Potion healthPotion)
        {
            player.Health = player.Health + (50 + player.PlayerLevel);
            healthPotion.Quantity--;
            if (player.Health >= player.MaxHealth)
            {
                player.Health = player.MaxHealth;
            }
        }//End UseHealthPotion()

        public static void UseManaPotion(Player player, Potion manaPotion)
        {
            player.Mana = player.Mana + (50 + player.PlayerLevel);
            manaPotion.Quantity--;
            if (player.Mana >= player.MaxMana)
            {
                player.Mana = player.MaxMana;
            }
        }//END UserManaPotion


    }//END CLASS

}//END NAMESPACE
