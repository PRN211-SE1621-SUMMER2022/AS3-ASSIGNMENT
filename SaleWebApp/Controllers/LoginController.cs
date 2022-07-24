using BusinessObject.Models;
using DataAccess;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SaleWebApp.Controllers
{
    public class LoginController : Controller
    {
        IMemberRepository memberRepository = new MemberRepository();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            bool isSuccess = false;

            Member member;
            if (memberRepository.CheckLoginFromAccountInFile(userName, password))
            {
                member = new Member()
                {
                    Email = userName,
                    Password = password
                };
                HttpContext.Session.SetString("Role", "ADMIN");
                isSuccess = true;
            }
            else
            {
                member = memberRepository.CheckLogin(userName, password);
            }
            if (member != null)
            {
                isSuccess = true;
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(member));
            }

            if (isSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["IsSuccess"] = false;
            return RedirectToAction("Index", "Login");
        }
    }
}
