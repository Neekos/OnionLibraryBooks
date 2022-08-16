using Microsoft.AspNetCore.Mvc;
using OnionLibrary.DAL.Interfaces;
using System.Diagnostics;
using OnionLibrary.Domain.Models;
using OnionLibrary.Service.Interfaces;
using OnionLibrary.Domain.Response;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OnionLibrary.Domain.ViewModels.User;

namespace OnionLibrary.Controllers
{
    public class BookController:Controller
    {
        private readonly IBookService _bookServices;
        public BookController(IBookService bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _bookServices.GetBooks();
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _bookServices.GetBook(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _bookServices.DeleteBook(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditBook(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var response = await _bookServices.GetBook(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    
                        await _bookServices.CreateBook(model);
                }
                else
                {
                    await _bookServices.EditBook(model.Id, model);
                }
            }
            return RedirectToAction("Index");

        }
    }
}
