using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UCP1_PAW_089_C.Models;

namespace UCP1_PAW_089_C.Controllers
{
    public class loginController : Controller
    {
        db database = new db();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind] Ad_login ad)
        {
            int res = database.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "Login Admin Berhasil";
                Response.Redirect("Home/Index");
            }
            else
            {
                TempData["msg"] = "Login Gagal";
            }
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
