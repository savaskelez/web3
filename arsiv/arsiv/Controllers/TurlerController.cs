using arsiv.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace arsiv.Controllers
{
    [Authorize]
    public class TurlerController : Controller
    {
        ArsivEntities db = new ArsivEntities();
        // GET: Turler
        public ActionResult Index()
        {
            var model = db.Turler.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Kaydet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydet(Turler turler)
        {
            if (turler.ID == 0)
            {
                db.Turler.Add(turler);
            }
            else
            {
                var guncellenecekTurler = db.Turler.Find(turler.ID);
                if (guncellenecekTurler == null)
                {
                    return HttpNotFound();
                }
                guncellenecekTurler.Turismi = turler.Turismi;
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Turler");
        }
        public ActionResult Guncelle(int ID)
        {
            var model = db.Turler.Find(ID);
            if (model == null)
                return HttpNotFound();
            return View("Kaydet",model);
        }
        public ActionResult Sil(int ID)
        {
            var silinecekTurler = db.Turler.Find(ID);
            if (silinecekTurler == null)
                return HttpNotFound();
            db.Turler.Remove(silinecekTurler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    }
