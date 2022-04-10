using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Web.Service
{
   public interface IGenericService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int arg);

        Task<T> Update(T arg);

        Task<List<T>> Insert(T arg);
        Task<List<T>> Delete(int arg);

    }
}
