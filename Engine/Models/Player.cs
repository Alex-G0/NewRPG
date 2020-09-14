using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Engine.ViewModels;
using Engine.Models;

namespace Engine
{
    public class Player : BaseNotificationClass
    {
        private int _health { get; set; }
        private int _gold { get; set; }

        public string Name { get; set; }
        public string Race { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Charisma { get; set; }
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }
        public int Gold 
        { 
            get { return _gold; } 
            set
            {
                _gold = value;
                OnPropertyChanged(nameof(Gold));
            }
        }
        public ObservableCollection<Item> Inventory { get; set; }
        public ObservableCollection<InventoryItem> GroupedInventory { get; set; }
        
        public List<Item> Weapons => Inventory.Where(i => i is Weapon).ToList();
        public List<Item> Armors => Inventory.Where(i => i is Armor).ToList();
        public List<Item> Gloves => Inventory.Where(i => i is Glove).ToList();
        public List<Item> Boots => Inventory.Where(i => i is Boot).ToList();
        
        public void AddItemToInventory(Item item)
        {
            Inventory.Add(item);
            if (item.IsUnique)
                GroupedInventory.Add(new InventoryItem(item, 1));
            else
            {
                if (!GroupedInventory.Any(gi => gi.GameItem.ItemID == item.ItemID))
                    GroupedInventory.Add(new InventoryItem(item, 0));
                GroupedInventory.First(gi => gi.GameItem.ItemID == item.ItemID).Quantity++;
            }            
            OnPropertyChanged(nameof(Weapons));
            OnPropertyChanged(nameof(Armors));
            OnPropertyChanged(nameof(Gloves));
            OnPropertyChanged(nameof(Boots));
        }
        public void RemoveItemFromInventory(Item item)
        {
            Inventory.Remove(item);
            InventoryItem inventoryItemToRemove = GroupedInventory.FirstOrDefault(gi => gi.GameItem == item);
            if(inventoryItemToRemove !=null)
            {
                if (inventoryItemToRemove.Quantity == 1)
                    GroupedInventory.Remove(inventoryItemToRemove);
                else
                    inventoryItemToRemove.Quantity--;
            }
            OnPropertyChanged(nameof(Weapons));
            OnPropertyChanged(nameof(Armors));
            OnPropertyChanged(nameof(Gloves));
            OnPropertyChanged(nameof(Boots));
        }
        public Player(string name, string race, int str, int agi, int con, int itl, int chr, int health, int gold)
        {
            Name = name;
            Race = race;
            Strength = str;
            Agility = agi;
            Constitution = con;
            Intelligence = itl;
            Charisma = chr;
            Health = health;
            Gold = gold;
            Inventory = new ObservableCollection<Item>();
            GroupedInventory = new ObservableCollection<InventoryItem>();
        }
    }
}
