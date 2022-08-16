using OnionLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.DAL.Interfaces
{
    public interface IUserRepository:IBaseRepository<Book>
    {
        Task<Book> GetByName(string name);
    }
}
