using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeCV.Models.Entity;

namespace ProjeCV.Controllers
{
    public class SifrelerController : Controller
    {
        // GET: Sifreler
        DbMvcCvEntities1 db = new DbMvcCvEntities1();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult YeniSifre()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSifre(TBLKULLANIC p)
        {
            db.TBLKULLANIC.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}