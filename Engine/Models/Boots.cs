using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Boot : Item
    {
        public int PhysResistance { get; set; }
        public Boot(int itemID, string itemName, int physResistance) : base (itemID, itemName, true)
        {
            PhysResistance = physResistance;
        }
        public Boot Clone()
        {
            return new Boot(ItemID, ItemName, PhysResistance);
        }
    }
}
