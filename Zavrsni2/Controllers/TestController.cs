using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;
using System.Data.Entity;

namespace Zavrsni2.Controllers
{
    public class TestController : BaseController
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Uloge()
        {
            IEnumerable<Uloga> a = db.Uloga;
            return View(a);
        }
    }
}