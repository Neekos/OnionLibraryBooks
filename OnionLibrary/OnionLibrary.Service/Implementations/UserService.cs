using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionLibrary.DAL.Interfaces;
using OnionLibrary.Domain.Models;
using OnionLibrary.Domain.Response;
using OnionLibrary.Domain.ViewModels.User;
using OnionLibrary.Service.Interfaces;

namespace OnionLibrary.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IBaseResponse<User>> GetBook(int id)
        {
            var baseResponse = new BaseResponse<User>();
            
            try
            {
                var user = await _userRepository.Get(id);
                if (user == null)
                {
                    baseResponse.Description = "user not Found";
                    baseResponse.Status = Domain.Enum.StatusCode.BookNotFound;
                    return baseResponse;
                }
                baseResponse.Data = user;
                baseResponse.Status = Domain.Enum.StatusCode.Ok;

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[GetBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }

        }


        public async Task<IBaseResponse<User>> GetByNameBook(string name)
        {
            var baseResponse = new BaseResponse<User>();

            try
            {
                var user = await _userRepository.GetByName(name);
                if (user == null)
                {
                    baseResponse.Description = "user not Found";
                    baseResponse.Status = Domain.Enum.StatusCode.BookNotFound;
                    return baseResponse;
                }
                baseResponse.Data = user;
                baseResponse.Status = Domain.Enum.StatusCode.Ok;

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[GetByNameBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }

        }

        public async Task<IBaseResponse<IEnumerable<User>>> GetBooks()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            try
            {
                var user = await _userRepository.Select();
                if (user.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.Status = Domain.Enum.StatusCode.Ok;
                    return baseResponse;
                }
                baseResponse.Data = user;
                baseResponse.Status = Domain.Enum.StatusCode.Ok;

                return baseResponse;
                
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Description = $"[GetBooks]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }
            
        }

        public async Task<IBaseResponse<UserViewModel>> CreateBook(UserViewModel userViewModel)
        {
            var baseResponse = new BaseResponse<UserViewModel>();
            try
            {
                var user = new User()
                {
                    Name = userViewModel.Name,
                    Surname = userViewModel.Surname,
                    Patronymic = userViewModel.Patronymic,
                    Avatar = userViewModel.Avatar,
                    Birthday = userViewModel.Birthday,
                    DateRegistration = userViewModel.DateRegistration
                };
                await _userRepository.Create(user);
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserViewModel>()
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
                var user = await _userRepository.Get(id);
                if (user == null)
                {
                    baseResponse.Description = "user not Found";
                    baseResponse.Status = Domain.Enum.StatusCode.Ok;
                    return baseResponse;
                }
                await _userRepository.Delete(user);//не понятно надо разобратся
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

        public async Task<IBaseResponse<User>> EditBook(int id, UserViewModel model)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var user = await _userRepository.Get(id);
                if (user == null)
                {
                    baseResponse.Description = "user not Found";
                    baseResponse.Status = Domain.Enum.StatusCode.BookNotFound;
                    return baseResponse;
                }
                user.Name = model.Name;
                

                await _userRepository.UpDate(user);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = $"[EditBook]: {ex.Message}",
                    Status = Domain.Enum.StatusCode.Error
                };
            }
            //throw new NotImplementedException();
        }
    }
}
