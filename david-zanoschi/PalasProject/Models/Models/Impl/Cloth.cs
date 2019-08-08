using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalasProject.Models.Impl
{
    public class Cloth
    {
        public int Id { get; set; }
        public ClothColor Color { get; set; }    
    }

    public enum ClothColor
    {
        Red,
        Green,
        Blue,
        Black,
        White
    }
}
