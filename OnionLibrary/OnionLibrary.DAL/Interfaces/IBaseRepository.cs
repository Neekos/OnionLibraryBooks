using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
namespace OnionLibrary.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);
        Task<T> Get(int id);

        Task<IEnumerable<T>> Select();

        Task<bool> Delete(T entity);
        Task<T> UpDate(T entity);
    }
}
