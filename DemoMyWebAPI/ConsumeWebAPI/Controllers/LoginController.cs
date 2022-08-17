using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebAPI.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            LoginViewModel obj = new LoginViewModel();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel objuserlogin)
        {
            var display = Userloginvalues().Where(m => m.Username == objuserlogin.Username && m.Password == objuserlogin.Password).FirstOrDefault();
            if (display != null)
            {
                ViewBag.Status = "CORRECT UserName and Password";
            }
            else
            {
                ViewBag.Status = "INCORRECT UserName or Password";
            }
            return View(objuserlogin);
        }

        public List<LoginViewModel> Userloginvalues()
        {
            List<LoginViewModel> objModel = new List<LoginViewModel>();
            objModel.Add(new LoginViewModel { Username = "user1", Password = "password1" });
            objModel.Add(new LoginViewModel { Username = "user2", Password = "password2" });
            objModel.Add(new LoginViewModel { Username = "user3", Password = "password3" });
            objModel.Add(new LoginViewModel { Username = "user4", Password = "password4" });
            objModel.Add(new LoginViewModel { Username = "user5", Password = "password5" });
            return objModel;
        }
    }
}