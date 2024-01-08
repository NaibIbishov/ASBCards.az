using Business.Abstract;
using Business.Concrete;
using Helper.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCards.asb.az.Models;

namespace WebCards.asb.az.Controllers
{
    //[Authorize(Roles = RoleKeywords.UserRole)]
    //[Authorize(Roles = RoleKeywords.AdminRole)]
    public class HomeController : Controller
    { 
        private readonly IOrderCardService _orderCardService;

        public HomeController(IOrderCardService orderCardService)
        {
            _orderCardService = orderCardService;
        }

        public IActionResult Index()
        {
            var value=_orderCardService.GetAll();
            return View(value);
        }

        public IActionResult Delete(int id)
        {
            _orderCardService.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = RoleKeywords.UserRole)]
        public IActionResult Account()
        {
            var value = _orderCardService.GetAll();
            return View(value);
        }


    }
}