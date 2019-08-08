using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalasProject.Repositories.Interfaces
{
    public interface IParkingRepo<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task InsertAsync(T parkingentity);

        T UpdateAsync(T parkingentity);

        Task DeleteAsync(int id);

        Task SaveAsync();

    }
}
