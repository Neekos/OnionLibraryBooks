using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionLibrary.Domain.Models;
using OnionLibrary.Domain.Response;
using OnionLibrary.Domain.ViewModels.Shelf;

public interface IShelfService
{
    Task<IBaseResponse<IEnumerable<Shelf>>> GetShelfs();
    Task<IBaseResponse<Shelf>> GetShelf(int id);
    Task<IBaseResponse<bool>> DeleteShelf(int id);
    Task<IBaseResponse<ShelfViewModel>> CreateShelf(ShelfViewModel shelfViewModal);
    Task<IBaseResponse<Shelf>> EditShelf(int id, ShelfViewModel model);
}
