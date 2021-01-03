using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class YeteneklerController : Controller
    {
        DbMvcCvEntities1 db = new DbMvcCvEntities1();

        // GET: Yeteneklerim
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger4 = db.TBLSKILLS.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TBLSKILLS p)
        {
            db.TBLSKILLS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var yetenek = db.TBLSKILLS.Find(id);
            db.TBLSKILLS.Remove(yetenek);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YetenekGetir(int id)
        {
            var veriler = db.TBLSKILLS.Find(id);
            return View("YetenekGetir", veriler);
        }
        public ActionResult Guncelle(TBLSKILLS p)
        {
            var degerler = db.TBLSKILLS.Find(p.ID);
            degerler.SKILL = p.SKILL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}