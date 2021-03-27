using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BUUGARUSTOK.Models.Entity;

namespace BUUGARUSTOK.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satıs
        FinishProjectVtbEntities6 db = new FinishProjectVtbEntities6();
        public ActionResult Index()
        {
         
            var degerler = db.TBLSATISLAR.ToList();
            return View(degerler);
        }
    }
}