using Business.Abstract;
using DTO.DTOEntity;
using Helper.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebCards.asb.az.Controllers
{
    [Authorize(Roles = RoleKeywords.UserRole)]
    //[Authorize(Roles = RoleKeywords.AdminRole)]
    public class OrderCardController : Controller
    {
        private readonly IOrderCardService _orderCardService;
        
     

        public OrderCardController(IOrderCardService orderCardService)
        {
            _orderCardService = orderCardService;
           
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value=_orderCardService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult Index(OrderCardDTO or)
        {
           
            _orderCardService.Update(or);
            
          
            return RedirectToAction("Index","Home");
        }

        public IActionResult Details()
        {

            var value = _orderCardService.GetAll();

            return View(value);
        } 
        
        



        //public IActionResult Sistem()
        //{

        //    var value = _orderCardService.GetAll();

        //    return View(value);
        //}

        //public IActionResult PlasticCards()
        //{

        //    var value = _orderCardService.GetAll();

        //    return View(value);
        //}




    }
}
