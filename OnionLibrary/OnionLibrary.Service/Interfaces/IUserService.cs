using OnionLibrary.Domain.Models;
using OnionLibrary.Domain.Response;
using OnionLibrary.Domain.ViewModels.User;

namespace OnionLibrary.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<IEnumerable<User>>> GetBooks();
        Task<IBaseResponse<User>> GetBook(int id);
        Task<IBaseResponse<bool>> DeleteBook(int id);
        Task<IBaseResponse<UserViewModel>> CreateBook(UserViewModel bookViewModal);
        Task<IBaseResponse<User>> EditBook(int id, UserViewModel model);
    }
}
