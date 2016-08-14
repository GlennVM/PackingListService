using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackingList.Models
{
    public class ItemRepository : IItemRepository
    {
        Item[] items = new Item[]
        {
            new Item {Id = 1, Name = "TShirt"},
            new Item {Id = 2, Name = "Broek" }
        };
        public Item AddItem(Item item)
        {
            this.items.ToList().Add(item);
            return item;
        }

        public bool DeleteItem(Item item)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (this.items[i].Name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return items;
        }

        public Item GetItem(string name)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Name == name)
                {
                    return items[i];
                }
            }
            return null;
        }

        public Item UpdateItem(Item item)
        {
            return item;
        }
    }
}