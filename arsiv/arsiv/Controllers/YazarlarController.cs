using arsiv.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace arsiv.Controllers
{
    [Authorize]
    public class YazarlarController : Controller
    {
        ArsivEntities db = new ArsivEntities();
        // GET: Yazarlar
        public ActionResult Index()
        {
            var model = db.Yazarlar.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(Yazarlar yazarlar)
        {
            if (yazarlar.ID == 0)
            {
                db.Yazarlar.Add(yazarlar);
            }
            else
            {
                var guncellenecekYazarlar = db.Yazarlar.Find(yazarlar.ID);
                if (guncellenecekYazarlar == null)
                {
                    return HttpNotFound();
                }
                guncellenecekYazarlar.AdSoyad = yazarlar.AdSoyad;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Yazarlar");
        }
        public ActionResult Guncelle(int ID)
        {
            var model = db.Yazarlar.Find(ID);
            if (model == null)
                return HttpNotFound();
            return View("Kaydet", model);
        }
        public ActionResult Sil(int ID)
        {
            var silinecekYazarlar = db.Yazarlar.Find(ID);
            if (silinecekYazarlar == null)
                return HttpNotFound();
            db.Yazarlar.Remove(silinecekYazarlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
