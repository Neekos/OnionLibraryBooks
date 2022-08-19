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
    public class ShelfRepository:IShelfRepository
    {
        private readonly ApplicationDbContext _db;
        public ShelfRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Shelf entity)
        {
            //добавляем
            await _db.Shelves.AddAsync(entity);
            //сохраняем изменения
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Shelf entity)
        {
            _db.Shelves.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Shelf> Get(int id)
        {
            return await _db.Shelves.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Shelf>> Select()
        {
            return await _db.Shelves.ToListAsync();
        }

        public async Task<Shelf> UpDate(Shelf entity)
        {
            _db.Shelves.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
