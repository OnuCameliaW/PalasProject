using PalasProject.Models.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalasProject.Repositories
{
    //add this interface into separate folder
    public interface IParkingRepo<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task Insert(T parkingEntity);

        T Update(T parkingEntity);

        Task Delete(int id);

        Task Save();

    }
}
