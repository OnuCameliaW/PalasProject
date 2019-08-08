using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Models.Models.Implementation
{
    public class ParkingLot
    {
        public ParkingLot()
        {

        }

        public ParkingLot(string numberOfParkingSpots, bool isOpen, string floor, string description)
        {
            NumberOfParkingSpots = numberOfParkingSpots;
            IsOpen = isOpen;
            Floor = floor;
            Description = description;
        }

        [Key]
        public int ParkingLotId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
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
