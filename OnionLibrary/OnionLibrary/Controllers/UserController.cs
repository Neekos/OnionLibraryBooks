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
    public class UserController:Controller
    {
        private readonly IUserService _userServices;
        public UserController(IUserService userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _userServices.GetUsers();
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var response = await _userServices.GetUser(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userServices.DeleteUser(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Error");
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUser(int id)
        {
            if(id == 0)
            {
                return View();
            }
            var response = await _userServices.GetUser(id);
            if (response.Status == Domain.Enum.StatusCode.Ok)
            {
                return View(response.Data);

            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    
                        await _userServices.CreateUser(model);
                }
                else
                {
                    await _userServices.EditUser(model.Id, model);
                }
            }
            return RedirectToAction("Index");

        }
    }
}
