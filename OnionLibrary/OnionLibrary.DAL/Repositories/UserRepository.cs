using Microsoft.EntityFrameworkCore;
using OnionLibrary.DAL.Interfaces;
using OnionLibrary.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionLibrary.DAL.Repositories
{
    public class UserRepository : IBaseRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            //Переменная для использования модели из базы данных
            _db = db;
        }

        public async Task<bool> Create(User entity)
        {
            //создание нового юзера
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
            //throw new NotImplementedException();
        }

        public async Task<bool> Delete(User entity)
        {
            //Удаление юзера
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
            //throw new NotImplementedException();
        }

        public async Task<User> Get(int id)
        {
            //Получаем юзера по Id
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            //throw new NotImplementedException();
        }

        public async Task<User> GetByName(string name)
        {
            //Получить юзера по имени - но метод будет заменен на запрос из бд
            return await _db.Users.FirstOrDefaultAsync(x => x.Name == name);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> Select()
        {
            //получаем колекцию юзеров
            return await _db.Users.ToListAsync();
            //return _db.Books.ToList();
            //throw new NotImplementedException();
        }

        public async Task<User> UpDate(User entity)
        {
            //изменение данных юзера
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
            //throw new NotImplementedException();
        }
    }
}
