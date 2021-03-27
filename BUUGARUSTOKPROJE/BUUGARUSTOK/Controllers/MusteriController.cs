using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUUGARUSTOK.Models.Entity;

namespace BUUGARUSTOK.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        FinishProjectVtbEntities6 db = new FinishProjectVtbEntities6();
        public ActionResult Index(string p)
        {
            var degerler = from d in db.TBLMUSTERILER select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERILER.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL (int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriGuncelle(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGuncelle", mus);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            musteri.MUSTERIAD = p1.MUSTERIAD;
            musteri.MUSTERIADRES = p1.MUSTERIADRES;
            musteri.MUSTERIEMAIL = p1.MUSTERIEMAIL;
            musteri.MUSTERIINSTAGRAM = p1.MUSTERIINSTAGRAM;
            musteri.MUSTERISOYAD = p1.MUSTERISOYAD;
            musteri.MUSTERITEL = p1.MUSTERITEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}