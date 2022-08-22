using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionLibrary.DAL.Interfaces;
using OnionLibrary.Domain.Models;
using OnionLibrary.Domain.Response;
using OnionLibrary.Domain.ViewModels.Shelf;
using OnionLibrary.Service.Interfaces;

namespace OnionLibrary.Service.Implementations
{
    public class ShelfService : IShelfService
    {
        //подключаемся к методам для взаимодействия с бд
        private readonly IShelfRepository _shelfRepository;
        //создаем конструктор
        public ShelfService(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<IBaseResponse<ShelfViewModel>> CreateShelf(ShelfViewModel shelfViewModal)
        {
            //созадем  новый объект	
            var baseResponsе = new BaseResponse<ShelfViewModel>();
            //проверяем на исключение
            try
            {
                //создаем новый объект shelf
                var shelf = new Shelf()
                {
                    Title = shelfViewModal.Title,
                };
                //вызов метода взаимодействия с бд
                await _shelfRepository.Create(shelf);
            }
            catch (Exception ex)
            {
                //возравщаем объект об ошибке
                return new BaseResponse<ShelfViewModel>()
                {
                    //описание ошибки
                    Description = $"[CreateShelf]: {ex.Message}",
                    //статус ошибки
                    Status = Domain.Enum.StatusCode.Error
                };
            }
            return baseResponsе;
        }

        public async Task<IBaseResponse<bool>> DeleteShelf(int id)
        {
            //созадем  новый объект	
            var baseResponsе = new BaseResponse<bool>()
            {
                Data = true
            };
            //проверяем на исключение
            try
            {
                //получаем id
                var shelf = await _shelfRepository.Get(id);
                // если ссылки на данные нет 
                if (shelf == null)
                {
                    //записываем ошибку
                    baseResponsе.Description = "Shelf not found";
                    //устанавливаем статус 
                    baseResponsе.Status = Domain.Enum.StatusCode.ShelfNotFound;
                    //возвращаем ошибку
                    return baseResponsе;
                }
                baseResponsе.Status = Domain.Enum.StatusCode.Ok;
                //вызываем метод джинерик и удаляем обЪект
                await _shelfRepository.Delete(shelf);
                //возвращаем результат работы
                return baseResponsе;
            }
            catch (Exception ex)
            {
                //возравщаем объект об ошибке
                return new BaseResponse<bool>()
                {
                    //описание ошибки
                    Description = $"[DeleteShelf]: {ex.Message}",
                    //статус ошибки
                    Status = Domain.Enum.StatusCode.Error
                };
            }
        }

        public async Task<IBaseResponse<Shelf>> EditShelf(int id, ShelfViewModel model)
        {
            //созадем  новый объект	
            var baseResponsе = new BaseResponse<Shelf>();
            //проверяем на исключение
            try
            {
                //получаем id
                var shelf = await _shelfRepository.Get(id);
                // если ссылки на данные нет 
                if (shelf == null)
                {
                    //записываем ошибку
                    baseResponsе.Description = "Shelf not found";
                    //устанавливаем статус 
                    baseResponsе.Status = Domain.Enum.StatusCode.Ok;
                    //возвращаем ошибку
                    return baseResponsе;
                }

                shelf.Title = model.Title;
                //вызываем метод джинерик и удаляем обЪект
                await _shelfRepository.UpDate(shelf);
                //возвращаем результат работы
                return baseResponsе;
            }
            catch (Exception ex)
            {
                //возравщаем объект об ошибке
                return new BaseResponse<Shelf>()
                {
                    //описание ошибки
                    Description = $"[EditShelf]: {ex.Message}",
                    //статус ошибки
                    Status = Domain.Enum.StatusCode.Error
                };
            }
        }

        public async Task<IBaseResponse<Shelf>> GetShelf(int id)
        {
            //созадем  новый объект	
            var baseResponsе = new BaseResponse<Shelf>();
            //проверяем на исключение
            try
            {
                //получаем id
                var shelf = await _shelfRepository.Get(id);
                // если ссылки на данные нет 
                if (shelf == null)
                {
                    //записываем ошибку
                    baseResponsе.Description = "Shelf not found";
                    //устанавливаем статус 
                    baseResponsе.Status = Domain.Enum.StatusCode.Ok;
                    //возвращаем ошибку
                    return baseResponsе;
                }
                baseResponsе.Data = shelf;
                baseResponsе.Status = Domain.Enum.StatusCode.Ok;
                return baseResponsе;
            }
            catch (Exception ex)
            {
                //возравщаем объект об ошибке
                return new BaseResponse<Shelf>()
                {
                    //описание ошибки
                    Description = $"[GetShelf]: {ex.Message}",
                    //статус ошибки
                    Status = Domain.Enum.StatusCode.Error
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Shelf>>> GetShelfs()
        {
            //созадем  новый объект	
            var baseResponsе = new BaseResponse<IEnumerable<Shelf>>();
            //проверяем на исключение
            try
            {
                //получаем id
                var shelf = await _shelfRepository.Select();
                // если ссылки на данные нет 
                if (shelf == null)
                {
                    //записываем ошибку
                    baseResponsе.Description = "Shelf not found";
                    //устанавливаем статус 
                    baseResponsе.Status = Domain.Enum.StatusCode.Ok;
                    //возвращаем ошибку
                    return baseResponsе;
                }
                baseResponsе.Data = shelf;
                baseResponsе.Status = Domain.Enum.StatusCode.Ok;
                return baseResponsе;
            }
            catch (Exception ex)
            {
                //возравщаем объект об ошибке
                return new BaseResponse<IEnumerable<Shelf>>()
                {
                    //описание ошибки
                    Description = $"[GetShelf]: {ex.Message}",
                    //статус ошибки
                    Status = Domain.Enum.StatusCode.Error
                };
            }
        }
    }
}

