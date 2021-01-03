using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class HobilerController : Controller
    {
        // GET: Hobiler
        DbMvcCvEntities1 db = new DbMvcCvEntities1();
        
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger5 = db.TBLINTERESTS.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniHobi()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniHobi(TBLINTERESTS p)
        {
            db.TBLINTERESTS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hobi = db.TBLINTERESTS.Find(id);
            db.TBLINTERESTS.Remove(hobi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult HobiGetir(int id)
        {
            var veriler = db.TBLINTERESTS.Find(id);
            return View("HobiGetir", veriler);
        }
        public ActionResult Guncelle(TBLINTERESTS p)
        {
            var degerler = db.TBLINTERESTS.Find(p.ID);
            degerler.INTERESTS = p.INTERESTS;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}