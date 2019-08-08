using Models.Models.Implementation;

namespace Models.Models
{
    internal interface ICompany
    {
        void Hire(Person person);

        void Fire(Person person);
    }
}
