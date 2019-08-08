using System.Collections.Generic;
using System.Linq;

namespace Models.Models.Implementation
{
    public class ClothesShop : Shop<Cloth>
    {
        public Dictionary<Cloth, int> GiveAwayPercentagesPerItemDictionary { get; set; }

        public ClothesShop(int clothesStockCapacity) : base(clothesStockCapacity)
        {

        }

        public void AddOffer(int clothId, int percentage)
        {
            var cloth = Items.FirstOrDefault(c => c.Id == clothId);

            if (cloth != null)
            {
                GiveAwayPercentagesPerItemDictionary[cloth] = percentage;
            }
        }
    }
}
