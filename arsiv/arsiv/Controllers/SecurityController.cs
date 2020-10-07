using arsiv.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace arsiv.Controllers
{
    
    public class SecurityController : Controller
    {
        ArsivEntities db = new ArsivEntities();
        // GET: Security
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Kullanici kullanici)
        {
            var kullaniciInDb = db.Kullanici.FirstOrDefault(x => x.Ad == kullanici.Ad && x.Sifre == kullanici.Sifre);
            if (kullaniciInDb == null)
            {
                ViewBag.Mesaj = "Kullancı Adı veya Şifre Hatalı";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(kullaniciInDb.Ad,false);
                return RedirectToAction("Index", "İslem");
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}