using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//move this to its namespace

//rename folder to Implementation, or something like this
namespace PalasProject.Models.Impl
{
    public class Cloth
    {
        public int Id { get; set; }
        public ClothColor Color { get; set; }    
    }

    //move this enum somewhere else
    public enum ClothColor
    {
        Red,
        Green,
        Blue,
        Black,
        White
    }
}
