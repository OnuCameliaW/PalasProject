using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PalasProject.Models.Impl
{
    public class ParkingLot
    {
        [Key]
        public int ParkingLotId { get; set; }

        [Required]
        [Range(0, Int32.MaxValue)]
        public string NumberOfParkingSpots { get; set; }

        [DisplayName("Open")]
        public bool IsOpen { get; set; }

        [RegularExpression(@"^[A-Z]\-\d$")]
        public string Floor { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [IgnoreDataMember]
        public virtual ICollection<ParkingSpot> ParkingSpots { get; set; }

        public static ParkingLot CreateValidParkingLot()
        {
            //use contructor
            return new ParkingLot
            {
                NumberOfParkingSpots = "32",
                IsOpen = true,
                Floor = "A-5",
                Description = "Some parking lot"
            };
        }
    }
}
