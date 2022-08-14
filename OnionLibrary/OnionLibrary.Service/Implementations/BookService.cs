using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionLibrary.DAL.Interfaces;
using OnionLibrary.Domain.Models;
using OnionLibrary.Domain.Response;
using OnionLibrary.Domain.ViewModels.Book;
using OnionLibrary.Service.Interfaces;

namespace OnionLibrary.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IBaseResponse<Book>> GetBook(int id)
        {   
            try
            {
               var book = await _bookRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (book == null)
                {
                    return BaseResponse<BookViewModel>(){
                        BaseResponse.Description = "Book not Found";
                        BaseResponse.Status = Domain.Enum.StatusCode.BookNotFound;
                    };
                }
                

                var data = new BookViewModel()
                {
                    Title = book.Title,
                    Description = book.Description,
                    img = book.img,
                    IdUser = book.IdUser,
                    IdShelf = book.IdShelf,
                    IdCategory = book.IdCategory,
                };

                return BaseResponse<BookViewModel>(){
                    BaseResponse.Status = Domain.Enum.StatusCode.Ok;
                    BaseResponse.Data = data;
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"[GetBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }

        }


        public async Task<IBaseResponse<Book>> GetByNameBook(string name)
        {
            var baseResponse = new BaseResponse<Book>();

            try
            {
                var book = await _bookRepository.GetByName(name);
                if (book == null)
                {
                    baseResponse.Description = "Book not Found";
                    baseResponse.Status = Domain.Enum.StatusCode.BookNotFound;
                    return baseResponse;
                }
                baseResponse.Data = book;
                baseResponse.Status = Domain.Enum.StatusCode.Ok;

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"[GetByNameBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }

        }

        public async Task<IBaseResponse<IEnumerable<Book>>> GetBooks()
        {
            var baseResponse = new BaseResponse<IEnumerable<Book>>();
            try
            {
                var books = await _bookRepository.Select();
                if (books.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.Status = Domain.Enum.StatusCode.Ok;
                    return baseResponse;
                }
                baseResponse.Data = books;
                baseResponse.Status = Domain.Enum.StatusCode.Ok;

                return baseResponse;
                
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Book>>()
                {
                    Description = $"[GetBooks]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }
            
        }

        public async Task<IBaseResponse<BookViewModel>> CreateBook(BookViewModel bookViewModel)
        {
            var baseResponse = new BaseResponse<BookViewModel>();
            try
            {
                var book = new Book()
                {
                    Title = bookViewModel.Title,
                    Description = bookViewModel.Description,
                    img = bookViewModel.img,
                    IdUser = bookViewModel.IdUser,
                    IdShelf = bookViewModel.IdShelf,
                    IdCategory = bookViewModel.IdCategory,
                };
                await _bookRepository.Create(book);
            }
            catch (Exception ex)
            {
                return new BaseResponse<BookViewModel>()
                {
                    Description = $"[CreateBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteBook(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var book = await _bookRepository.Get(id);
                if (book == null)
                {
                    baseResponse.Description = "Book not Found";
                    baseResponse.Status = Domain.Enum.StatusCode.Ok;
                    return baseResponse;
                }
                await _bookRepository.Delete(book);//не понятно надо разобратся
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }
        }

        public async Task<IBaseResponse<Book>> EditBook(int id, BookViewModel model)
        {
            var baseResponse = new BaseResponse<Book>();
            try
            {
                var book = await _bookRepository.Get(id);
                if (book == null)
                {
                    baseResponse.Description = "Book not Found";
                    baseResponse.Status = Domain.Enum.StatusCode.BookNotFound;
                    return baseResponse;
                }
                book.Title = model.Title;
                book.Description = model.Description;
                book.img = model.img;
                book.IdUser = model.IdUser;
                book.IdShelf = model.IdShelf;
                book.IdCategory = model.IdCategory;

                await _bookRepository.UpDate(book);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Book>()
                {
                    Description = $"[EditBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }
            //throw new NotImplementedException();
        }
    }
}
