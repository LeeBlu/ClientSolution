using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientSolution.Api.IService
{
   public interface IGenericRepo<T>
    {
        List<T> GetAll();
        T GetById(int Id);

        T Update(T value);

        List<T> Insert(T value);
        List<T> Delete(int Id);
    }
}
