using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Armor : Item
    {
        public int PhysResistance { get; set; }
        public Armor(int itemID, string itemName, int physResistance) : base (itemID, itemName, true)
        {
            PhysResistance = physResistance;
        }
        public Armor Clone()
        {
            return new Armor(ItemID, ItemName, PhysResistance);
        }
    }
}
