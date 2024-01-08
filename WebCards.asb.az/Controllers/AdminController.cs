using Business.Abstract;
using DataAccess.Context;
using DTO.DTOEntity;
using Helper.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebCards.asb.az.Controllers
{
    [Authorize(Roles = RoleKeywords.AdminRole)]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        
        public AdminController(IUserService userService)
        {
            _userService = userService;
     
          
        }

        [HttpGet]
        public IActionResult Index()
        {
            var value = _userService.GetAll();
            return View(value);
        }

        
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Company()
        //{
        //    var value = _userService.GetAll();
        //    return View(value);
        //}


    }
}
