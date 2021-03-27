using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUUGARUSTOK.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace BUUGARUSTOK.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        FinishProjectVtbEntities6 db = new FinishProjectVtbEntities6();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if(!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var ks = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(ks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGuncelle(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGuncelle", ktgr);
        }
        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktg = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}