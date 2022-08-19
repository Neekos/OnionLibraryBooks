using OnionLibrary.Domain.Models;
using OnionLibrary.Domain.Response;
using OnionLibrary.Domain.ViewModels.User;

namespace OnionLibrary.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<IEnumerable<User>>> GetUsers();
        Task<IBaseResponse<User>> GetUser(int id);
        Task<IBaseResponse<bool>> DeleteUser(int id);
        Task<IBaseResponse<UserViewModel>> CreateUser(UserViewModel bookViewModal);
        Task<IBaseResponse<User>> EditUser(int id, UserViewModel model);
    }
}
