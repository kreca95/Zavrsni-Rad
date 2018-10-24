using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;
using System.Data;
using System.Data.Entity;
using System.Web.Helpers;
using System.Data.Entity.Migrations;

namespace Zavrsni2.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ProizvodiController : BaseController
    {
        // GET: Proizvodi
        public ActionResult Index()
        {

            //var model = new ProizvodiIndexViewModel
            //{
            //    ListaProizvoda = db.Proizvod
            //};
            ViewBag.ListaProizvoda = db.Proizvod;

            return View();
        }
        
        public ActionResult Dodaj()
        {
            ViewBag.Kategorija = db.Kategorija.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Proizvod proizvod, HttpPostedFileBase file)
        {
                     
            FileUpload.ResizeImage(file, 350, 200);
            proizvod.Slika = FileUpload.UploadFile(file);

            proizvod.DatumDodavanje = DateTime.Now;
            proizvod.ProdanaKolicina = 0;
            proizvod.Kolicina = 0;
            db.Proizvod.Add(proizvod);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Kategorija = db.Kategorija.ToList();
            var proizvod = db.Proizvod.Where(x => x.ID == id).SingleOrDefault();

            return View(proizvod);
        }
        [HttpPost]
        public ActionResult Edit(Proizvod proizvod, HttpPostedFileBase file)
        {
            ViewBag.Kategorija = db.Kategorija.ToList();
            if(ModelState.IsValid)
            {
                //FileUpload.DeleteFile(proizvod.Slika);
                if(file!=null)
                {
                    proizvod.Slika = FileUpload.UploadFile(file);
                    db.Proizvod.AddOrUpdate(proizvod);
                }
                else
                {
                    
                    proizvod.Slika = db.Proizvod.Find(proizvod.ID).Slika;
                    db.Proizvod.AddOrUpdate(proizvod);
                }

                db.SaveChanges();
                return RedirectToAction("index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var proizvod=db.Proizvod.Find(id);

            return View(proizvod);
        }

        public ActionResult Izbrisi(int? id)
        {
            var izbrisi = db.Proizvod.Find(id);
            db.Proizvod.Remove(izbrisi);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}