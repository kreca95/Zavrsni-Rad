using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;

namespace Zavrsni2.Controllers
{
    //[Authorize(Roles = ("Admin"))]

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var user = User.Identity.Name;

            ViewBag.ListaProizvoda = db.Proizvod.ToList();
            ViewBag.ListaBrandova = db.Brandovi;

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        public JsonResult GetId(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var proizvod = db.Proizvod.Find(id);
            return Json(proizvod,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddToCart(int? id)
        {
            var proizvod = db.Proizvod.Find(id);

            return Json(proizvod,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Rezervacija()
        {

            return View();
        }
    }
}