using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Glove : Item
    {
        public int PhysResistance { get; set; }
        public Glove(int itemID, string itemName, int physResistance) : base (itemID, itemName, true)
        {
            PhysResistance = physResistance;
        }
        public Glove Clone()
        {
            return new Glove(ItemID, ItemName, PhysResistance);
        }
    }
}
