using System.Collections.Generic;
using Models.Models.Interfaces;

namespace Models.Models.Implementation
{
    public class Shop<T> : IShop<T>
    {
        public int ItemStockCapacity { get; }

        public List<T> Items { get; set; }

        public Shop(int itemStockCapacity)
        {
            ItemStockCapacity = itemStockCapacity;
            Items = new List<T>();
        }

        public void RefillStock(List<T> itemsToAdd)
        {
            Items.AddRange(itemsToAdd);
        }

        public void SellItem(T item)
        {
            Items.Remove(item);
        }
    }
}
