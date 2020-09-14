using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class ItemFactory
    {
        private static List<Item> _items;
        static ItemFactory()
        {
            _items = new List<Item>();
            _items.Add(new Weapon(00, "Fist", 1, 2));
            _items.Add(new Weapon(01, "Wooden club", 2, 4));
            _items.Add(new Weapon(02, "Short sword", 3, 5));
            _items.Add(new Item(03, "Rusty key"));
            _items.Add(new Item(04, "Crowbar"));
            _items.Add(new Item(05, "Health potion"));
            _items.Add(new Armor(06, "Leather armor", 1));
            _items.Add(new Glove(07, "Old gloves", 1));
            _items.Add(new Boot(08, "Holey shoes", 1));

        }
        public static Item CreateItem(int itemID)
        {
            Item item = _items.FirstOrDefault(itm => itm.ItemID == itemID);

            if (item != null)
            {
                if (item is Weapon)
                    return (item as Weapon).Clone();
                if (item is Armor)
                    return (item as Armor).Clone();
                if (item is Glove)
                    return (item as Glove).Clone();
                if (item is Boot)
                    return (item as Boot).Clone();
                return item.Clone();
            }
            return null;
        }

    }
}
