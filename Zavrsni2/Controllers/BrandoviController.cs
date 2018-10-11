using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;
using System.Data.Entity.Migrations;


namespace Zavrsni2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BrandoviController : BaseController
    {
        // GET: Brandovi
        public ActionResult Index()
        {

            ViewBag.ListaBrandova = db.Brandovi.ToList();
            return View();
        }

        public ActionResult Dodaj()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Brandovi brand,HttpPostedFileBase file)
        {
            brand.Slika = FileUpload.UploadFile(file);
            db.Brandovi.Add(brand);

            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            var brand = db.Brandovi.Where(x => x.ID == id).SingleOrDefault();

            return View(brand);
        }

        [HttpPost]
        public ActionResult Edit(Brandovi brand, HttpPostedFileBase file)
        {
            
            if (ModelState.IsValid)
            {
                //FileUpload.DeleteFile(proizvod.Slika);
                if (file!=null)
                {
                    brand.Slika = FileUpload.UploadFile(file);
                    db.Brandovi.AddOrUpdate(brand);
                }
                else
                {
                    brand.Slika = db.Brandovi.Find(brand.ID).Slika;
                    db.Brandovi.AddOrUpdate(brand);
                }
                db.SaveChanges();   
                return RedirectToAction("index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var brand = db.Brandovi.Find(id);

            return View(brand);
        }
        public ActionResult Izbrisi(int? id)
        {
            var izbrisi = db.Brandovi.Find(id);
            db.Brandovi.Remove(izbrisi);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}