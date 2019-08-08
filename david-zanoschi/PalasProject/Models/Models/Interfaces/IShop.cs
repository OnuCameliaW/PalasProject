using System.Collections.Generic;

namespace Models.Models
{
    public interface IShop<T>
    {
        void SellItem(T item);

        void RefillStock(List<T> itemsToAdd);
    }
}
