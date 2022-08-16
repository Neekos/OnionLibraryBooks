using OnionLibrary.Domain.Models;
using OnionLibrary.Domain.Response;
using OnionLibrary.Domain.ViewModels.Book;

namespace OnionLibrary.Service.Interfaces
{
    public interface IBookService
    {
        Task<IBaseResponse<IEnumerable<Book>>> GetBooks();
        Task<IBaseResponse<Book>> GetBook(int id);
        Task<IBaseResponse<bool>> DeleteBook(int id);
        Task<IBaseResponse<BookViewModel>> CreateBook(BookViewModel bookViewModal);
        Task<IBaseResponse<Book>> EditBook(int id, BookViewModel model);
    }
}
