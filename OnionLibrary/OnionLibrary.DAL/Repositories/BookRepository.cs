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
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Book entity)
        {
            await _db.Books.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
            //throw new NotImplementedException();
        }

        public async Task<bool> Delete(Book entity)
        {
            _db.Books.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
            //throw new NotImplementedException();
        }

        public async Task<Book> Get(int id)
        {
            return await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            //throw new NotImplementedException();
        }

        public async Task<Book> GetByName(string name)
        {
            return await _db.Books.FirstOrDefaultAsync(x => x.Title == name);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> Select()
        {
            return await _db.Books.ToListAsync();
            //return _db.Books.ToList();
            //throw new NotImplementedException();
        }

        public async Task<Book> UpDate(Book entity)
        {
            _db.Books.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
            //throw new NotImplementedException();
        }
    }
}
