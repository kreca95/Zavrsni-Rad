using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;
namespace Zavrsni2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Statistika()
        {
            Statistika model = new Models.Statistika()
            {
                Najprodavaniji =db.Proizvod.OrderByDescending(x => x.ProdanaKolicina).Take(5).ToList(),
                Najneprodavaniji= db.Proizvod.OrderBy(x => x.ProdanaKolicina).Take(5).ToList(),
            };
            ViewBag.Najprodavaniji = db.Proizvod.OrderByDescending(x => x.ProdanaKolicina).Take(5).ToList();
            return View(model);
        }
    }
}