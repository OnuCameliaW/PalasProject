using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalasProject.Models.Impl
{
    public class Shop<T> : IShop<T>
    {

        public readonly int ItemStockCapacity;
        public List<T> Items { get; set; }

        public Shop(int itemStockCapacity)
        {
            Items = new List<T>();
        }

        public void RefillStock(List<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                Items.Add(item);
            }
        }

        public void SellItem(T item)
        {
            Items.Remove(item);
        }
    }
}
