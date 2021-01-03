using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;
using ProjeCV.Models.Sinif;

namespace ProjeCV.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        DbMvcCvEntities1 db = new DbMvcCvEntities1();
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLABOUT.ToList();
            return View(cs);
        }
        public ActionResult VeriGetir(int id)
        {
            var veriler = db.TBLABOUT.Find(id);
            return View("VeriGetir", veriler);
        }
        public ActionResult Guncelle(TBLABOUT p)
        {
            var degerler = db.TBLABOUT.Find(p.ID);
            degerler.NAME = p.NAME;
            degerler.SURNAME = p.SURNAME;
            degerler.PHONE = p.PHONE;
            degerler.MAIL = p.MAIL;
            degerler.ADDRESS = p.ADDRESS;
            degerler.ABOUT = p.ABOUT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}