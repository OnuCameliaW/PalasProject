using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalasProject.Models.Impl
{
    public class Company : ICompany
    {
        public List<Person> Employees { get; set; }

        public void Fire(Person person)
        {
            if (Employees.Contains(person))
            {
                Employees.Remove(person);
            }
        }

        public void Hire(Person person)
        {
            if (!Employees.Contains(person))
            {
                Employees.Add(person);
            }
        }
    }
}
