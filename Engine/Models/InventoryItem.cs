using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class InventoryItem : BaseNotificationClass
    {
        private Item _gameItem;
        private int _quantity;
        public Item GameItem
        {
            get { return _gameItem; }
            set
            {
                _gameItem = value;
                OnPropertyChanged(nameof(GameItem));                   
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public InventoryItem(Item item, int quantity)
        {
            GameItem = item;
            Quantity = quantity;
        }
    }
}
