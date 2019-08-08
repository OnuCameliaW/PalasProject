using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PalasProject.Models.Impl
{
    public class ParkingSpot
    {
        public int Id { get; set; }

        [DisplayName("Available")]
        public bool IsAvailable { get; set; }

        [IgnoreDataMember]
        public virtual ParkingLot ParkingLot { get; set; }
    }
}
