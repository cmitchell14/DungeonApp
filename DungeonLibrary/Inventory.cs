using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Inventory
    {

        //fields

        //props
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEquippable { get; set; }


        //ctors
        public Inventory(string name, bool isEquippable, string description)
        {
            Name = name;
            IsEquippable = isEquippable;
            Description = description;
        }//END FQCTOR

        //methods
        public override string ToString()
        {
            return string.Format($"  {Name}:   {Description}\n  {(IsEquippable ? "Item is Equippable" : "")}");
        }//END ToString()

    }//END CLASS

}//END NAMESPACE
