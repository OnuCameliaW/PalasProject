using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalasProject.Models.Impl
{
    public class ClothesShop<T> : Shop<Cloth>
    {
        public Dictionary<Cloth, int> GiveAwayPercentagesPerItemDictionary { get; set; }

        public ClothesShop(int clothesStockCapacity) : base(clothesStockCapacity)
        {

        }

        public void AddOffer(int clothId, int percentage)
        {
            Cloth cloth = Items.FirstOrDefault(c => c.Id == clothId);

            if (cloth != null)
            {
                GiveAwayPercentagesPerItemDictionary[cloth] = percentage;
            }
        }
    }
}
