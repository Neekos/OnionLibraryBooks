using Microsoft.AspNetCore.Mvc;
using OnionLibrary.DAL.Interfaces;
using System.Diagnostics;
using OnionLibrary.Domain.Models;
using OnionLibrary.Service.Interfaces;
using OnionLibrary.Domain.Response;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OnionLibrary.Domain.ViewModels.Shelf;
using OnionLibrary.Service.Implementations;

namespace OnionLibrary.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfService _shelfServices;
        public ShelfController(IShelfService shelfService)
        {
            _shelfServices = shelfService;
        }
        // GET: ShelfController
        public async Task<IActionResult> Index()
        {
            var response = await _shelfServices.GetShelfs();
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        // GET: ShelfController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _shelfServices.GetShelf(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        // GET: ShelfController/Create
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var response = await _shelfServices.GetShelf(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        // POST: ShelfController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateShelf(ShelfViewModel model)
        {
            var response = await _shelfServices.CreateShelf(model);
            return RedirectToAction("Index");
        }

        // GET: ShelfController/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _shelfServices.GetShelf(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        // POST: ShelfController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> EditShelf(ShelfViewModel model)
        {
            var response = await _shelfServices.EditShelf(model.Id, model);
            return RedirectToAction("Index");
        }

        // GET: ShelfController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _shelfServices.GetShelf(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        // POST: ShelfController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteShelf(int id)
        {
          
            var response = await _shelfServices.DeleteShelf(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Error");
        }
    }
}
