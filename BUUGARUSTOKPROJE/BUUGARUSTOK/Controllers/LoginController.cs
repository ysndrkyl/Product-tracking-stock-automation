using BUUGARUSTOK.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BUUGARUSTOK.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        FinishProjectVtbEntities6 db = new FinishProjectVtbEntities6();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AdminLogin(Admin c)
        {
            var bilgiler = db.Admin.FirstOrDefault(x => x.KullanıcıAD == c.KullanıcıAD && x.Sifre == c.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAD, false);
                Session["KullanıcıAD"] = bilgiler.KullanıcıAD.ToString();
                return RedirectToAction("Index", "Kategori");

            }
            else
            {
              return  RedirectToAction("Index", "Login");
            }
        }


    }
}