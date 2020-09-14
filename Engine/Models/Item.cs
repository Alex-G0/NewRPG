using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public bool IsUnique { get; set; }
        public Item(int itemID, string itemName, bool isUnique = false)
        {
            ItemID = itemID;
            ItemName = itemName;
            IsUnique = isUnique;
        }
        public Item Clone()
        {
            return new Item(ItemID, ItemName, IsUnique);
        }
    }
}
