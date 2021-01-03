using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class DeneyimlerController : Controller
    {
        // GET: Deneyimler
        DbMvcCvEntities1 db = new DbMvcCvEntities1();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger2 = db.TBLEXPERIENCE.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniDeneyim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDeneyim(TBLEXPERIENCE p)
        {
            db.TBLEXPERIENCE.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            var deneyim = db.TBLEXPERIENCE.Find(id);
            db.TBLEXPERIENCE.Remove(deneyim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimGetir(int id)
        {
            var veriler = db.TBLEXPERIENCE.Find(id);
            return View("DeneyimGetir", veriler);
        }
        public ActionResult Guncelle(TBLEXPERIENCE p)
        {
            var degerler = db.TBLEXPERIENCE.Find(p.ID);
            degerler.TITLE = p.TITLE;
            degerler.SUBTITLE = p.SUBTITLE;
            degerler.DETAILS = p.DETAILS;
            degerler.DATE = p.DATE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}