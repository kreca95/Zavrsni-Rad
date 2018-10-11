using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;
namespace Zavrsni2.Controllers
{
    public class BaseController : Controller
    {
        protected WebShopEntities1 db = new WebShopEntities1();

        // GET: Base
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}