using System.Collections.Generic;

namespace Models.Models.Implementation
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
