using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;
using MoreLinq;

namespace Zavrsni2.Controllers
{
    public class EvidencijaController : BaseController
    {
        // GET: Evidencija
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
            
        {
            IEnumerable<Kosara> model = db.Kosara.ToList();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Detalji(int id)
        {
            Kosara kosara = db.Kosara.Find(id);
            IEnumerable<KosaraProizvod> model = kosara.KosaraProizvod.DistinctBy(x=> x.Proizvod.ID).ToList();

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public JsonResult Isporuci(int id)
        {
            Kosara kosara= db.Kosara.Find(id);
            kosara.JeLiIsporuceno = !kosara.JeLiIsporuceno;
            db.SaveChanges();
            return Json("succes", JsonRequestBehavior.AllowGet);
        }

        public ActionResult MojeKupnje()
        {
            ViewBag.kupnje = db.Kosara.Where(x => x.Email == User.Identity.Name);
            return View();
        }

        public ActionResult DetaljiMojeKupnje(int id)
        {

            var detalji = db.Kosara.Find(id);
            ViewBag.Detalji = detalji;
            ViewBag.Saldo = detalji.KosaraProizvod.Sum(x => x.Proizvod.Cijena * x.Kolicina);
            return View();
        }
    }
}