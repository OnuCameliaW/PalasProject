using Models.Models.Implementation;

namespace Models.Models.Interfaces
{
    internal interface ICompany
    {
        void Hire(Person person);

        void Fire(Person person);
    }
}
