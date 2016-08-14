using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackingList.Models
{
    public interface IItemRepository
    {
        Item AddItem(Item item);
        IEnumerable<Item> GetAllItems();
        Item GetItem(String name);
        Item UpdateItem(Item item);
        Boolean DeleteItem(Item item);
    }
}
