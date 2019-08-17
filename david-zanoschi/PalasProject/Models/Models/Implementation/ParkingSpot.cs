using System.ComponentModel;
using System.Runtime.Serialization;

namespace Models.Models.Implementation
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        [DisplayName("IsAvailable")]
        public bool IsAvailable { get; set; }

        [IgnoreDataMember]
        public virtual ParkingLot ParkingLot { get; set; }
    }
}
