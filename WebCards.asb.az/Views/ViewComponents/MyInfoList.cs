using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebCards.asb.az.Views.ViewComponents
{
    public class MyInfoList:ViewComponent
    {
        public readonly IUserService _userService;

        public MyInfoList(IUserService userService)
        {
            _userService = userService;
        }

        public IViewComponentResult Invoke()
        {
            var userid = Convert.ToInt32(HttpContext.User.FindFirst(x => x.Type == "Id")?.Value);

            var values = _userService.GetAll().Where(x=>x.ID==userid);
            return View(values);
        }
    }
}
