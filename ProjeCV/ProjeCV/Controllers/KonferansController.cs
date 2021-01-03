using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;
namespace ProjeCV.Controllers
{
    public class KonferansController : Controller
    {
        DbMvcCvEntities1 db = new DbMvcCvEntities1();
        // GET: Konferans
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger6 = db.TBLAWARDS.ToList();
            return View(cs);
        }
        [HttpGet]
        public ActionResult YeniKonferans()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKonferans(TBLAWARDS p)
        {
            db.TBLAWARDS.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var award = db.TBLAWARDS.Find(id);
            db.TBLAWARDS.Remove(award);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KonferansGetir(int id)
        {
            var veriler = db.TBLAWARDS.Find(id);
            return View("KonferansGetir", veriler);
        }
        public ActionResult Guncelle(TBLAWARDS p)
        {
            var degerler = db.TBLAWARDS.Find(p.ID);
            degerler.AWARD = p.AWARD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}