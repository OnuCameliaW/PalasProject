using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalasProject.Models.Impl;

namespace PalasProject.Models
{
    interface ICompany
    {
        void Hire(Person person);
        void Fire(Person person);
    }
}
