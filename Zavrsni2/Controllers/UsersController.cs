using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;

namespace Zavrsni2.Controllers
{
    //
    public class UsersController : BaseController
    {

        // GET: Users
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var user = db.User.Include(u => u.Uloga1);
            return View(user.ToList());
        }

        // GET: Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.User.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // GET: Users/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ID_Uloga = new SelectList(db.Uloga, "ID", "Naziv");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ime,Prezime,Email,Pass,ID_Uloga,Broj_mobitela,Uloga")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Uloga = new SelectList(db.Uloga, "ID", "Naziv", user.ID_Uloga);
            return View(user);
        }

        // GET: Users/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.User.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ID_Uloga = new SelectList(db.Uloga, "ID", "Naziv", user.ID_Uloga);
        //    return View(user);
        //}
        [Authorize(Roles ="Admin,User")]
        public ActionResult Edit()
        {
            
            User user = db.User.FirstOrDefault(x=> x.Email==User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ID_Uloga = new SelectList(db.Uloga, "ID", "Naziv", user.ID_Uloga);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult Edit([Bind(Include = "ID,Ime,Prezime,Email,Pass,ID_Uloga,Broj_mobitela,Uloga")] User user)
        {
            if (ModelState.IsValid)
            {
                var korisnik = db.User.Find(user.ID);
                korisnik.Ime = user.Ime;
                korisnik.Prezime = user.Prezime;
                korisnik.Pass = user.Pass;
                korisnik.Email = user.Email;
                db.SaveChanges();
                return View(user);
            }

            ViewBag.ID_Uloga = new SelectList(db.Uloga, "ID", "Naziv", user.ID_Uloga);
            return View(user);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult UrediKorisnika(int id)
        {
            var user = db.User.Find(id);
            
            return View(user);
        }

        // GET: Users/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User user = db.User.Find(id);
        //    if (user == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user);
        //}

        // POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    User user = db.User.Find(id);
        //    db.User.Remove(user);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
