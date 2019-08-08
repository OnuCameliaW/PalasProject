using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PalasProject.Models
{
    public interface IShop<T>
    {
        void SellItem(T item);
        void RefillStock(List<T> itemsToAdd);
    }
}
