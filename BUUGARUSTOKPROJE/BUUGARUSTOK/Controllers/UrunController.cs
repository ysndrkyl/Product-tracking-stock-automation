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
    public class UrunController : Controller
    {
        // GET: Urun
        FinishProjectVtbEntities6 db = new FinishProjectVtbEntities6();
        public ActionResult Index(int sayfa =1)
        {
            //var degerler = db.TBLURUNLER.ToList();
            var degerler = db.TBLURUNLER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(TBLURUNLER p1)
        {
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = ktg;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SIL (int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }
        public ActionResult Guncelle(TBLURUNLER p)
        {
            var urun = db.TBLURUNLER.Find(p.KITAPID);
            urun.KITAPAD = p.KITAPAD;
            //urun.KITAPKATEGORI = p.KITAPKATEGORI;
            var ktg = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.KITAPKATEGORI = ktg.KATEGORIID;
            urun.YAZAR = p.YAZAR;
            urun.KITAPTUR = p.KITAPTUR;
            urun.ALISFİYATGRV = p.ALISFİYATGRV;
            urun.KURGRV = p.KURGRV;
            urun.SATISFİYATTL = p.SATISFİYATTL;
            urun.DURUMU = p.DURUMU;
            urun.STOK = p.STOK;
            urun.KALANKARTL = p.KALANKARTL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
        [HttpGet]
        public ActionResult YeniSatis(int id)
        {
            var deger1 = db.TBLURUNLER.Find(id);
            ViewBag.dgr1 = deger1.KITAPID;
            ViewBag.dgr2 = deger1.SATISFİYATTL;
        
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(TBLSATISLAR p)
        {
            db.TBLSATISLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}