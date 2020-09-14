using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(int itemID, string itemName,int minDamage, int maxDamage) : base(itemID, itemName, true)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
        public Weapon Clone()
        {
            return new Weapon(ItemID, ItemName, MinDamage, MaxDamage);
        }
    }
}
