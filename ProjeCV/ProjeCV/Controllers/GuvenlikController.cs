using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjeCV.Models.Entity;

namespace ProjeCV.Controllers
{
    
    public class GuvenlikController : Controller
    {
        // GET: Guvenlik
        DbMvcCvEntities1 db = new DbMvcCvEntities1();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLKULLANIC t)
        {
            var bilgiler = db.TBLKULLANIC.FirstOrDefault(x => x.AD == t.AD && x.SIFRE == t.SIFRE);
            if(bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AD,false);
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return View();
            }
        }
    }
}