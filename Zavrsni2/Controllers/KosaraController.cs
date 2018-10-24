using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zavrsni2.Models;
using MoreLinq;
using System.Collections;
using Zavrsni2.Moje_klase;

namespace Zavrsni2.Controllers
{
    public class KosaraController : BaseController
    {
        // GET: Kosara
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult PovecajKolicinu(int id,string cookie,int kolicina)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var kosarica = db.Kosara.Where(x => x.Cookie.Equals(cookie)).First();
            var proizvod = db.KosaraProizvod.Where(x => x.Kosara_ID == kosarica.ID && x.Proizvod_ID==id).First();
            proizvod.Kolicina = kolicina;

            

            db.SaveChanges();
            return Json("succes",JsonRequestBehavior.AllowGet);
        }


       
        public JsonResult provjeriKosaricu(string cookie)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!String.IsNullOrWhiteSpace(cookie))
            {
                var kosarica = db.Kosara.Where(x => x.Cookie.Equals(cookie)).FirstOrDefault();
                if (kosarica != null)
                {
                    var pr = db.KosaraProizvod.Where(x => x.Kosara_ID == kosarica.ID && x.Kolicina>0).Select(x=> new {x.Proizvod,x.Kolicina }).DistinctBy(x=> x.Proizvod.ID).ToList();
                    return Json(pr, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Kosara novaKosara = new Kosara
                    {
                        Cookie = cookie,
                        Datum = DateTime.Now
                    };
                    //huyaaaaaaaaaaaa
                    db.Kosara.Add(novaKosara);
                    db.SaveChanges();
                    
                    return Json("dodano",JsonRequestBehavior.AllowGet);
                }
            }
            
            return Json("fail", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DodajUKosaru(string cookie,int idProizvoda)
        {
            db.Configuration.ProxyCreationEnabled = false;

            Kosara kosara = db.Kosara.Where(x => x.Cookie == cookie).FirstOrDefault();

            //kosara.JeLiKupljeno = "na cekanju";
            
            if (kosara!=null)
            {
                kosara.JeLiKupljeno = "na cekanju";
                KosaraProizvod kosaProiz = new KosaraProizvod
                {
                    Kosara_ID = kosara.ID,
                    Proizvod_ID = idProizvoda,
                    Kolicina = 1
                };

                db.KosaraProizvod.Add(kosaProiz);
                db.SaveChanges();
                return Json(kosaProiz, JsonRequestBehavior.AllowGet);
            }        
            else if(kosara==null)
            {
                Kosara novaKosara = new Kosara
                {
                    Cookie=cookie,
                    Datum=DateTime.Now
                };
                db.Kosara.Add(novaKosara);
                //db.SaveChanges();

                KosaraProizvod kosaProiz = new KosaraProizvod
                {
                    Kosara_ID = novaKosara.ID,
                    Proizvod_ID=idProizvoda
                };
                db.SaveChanges();

                return Json(kosaProiz, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("opasan fail neki");
            }
        }

        public JsonResult IzbrisiIzKosare(string cookie, int id)
        {
            var kosara = db.Kosara.Where(x => x.Cookie == cookie).FirstOrDefault();
            kosara.KosaraProizvod.First(x => x.Proizvod_ID.Equals(id)).Kolicina=0;

            db.SaveChanges();
            return Json("success",JsonRequestBehavior.AllowGet);
        }

        public JsonResult ZavrsiKupnju(string cookie,string email)
        {
            

            
            if (OduzmiKolicinu(cookie)==false)
            {
                return Json("fail", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Kosara kosara = db.Kosara.Where(x => x.Cookie.Equals(cookie)).FirstOrDefault();
                kosara.JeLiKupljeno = "da";
                kosara.Email = email;
                kosara.Datum = DateTime.Now;
                SendMail.SendMailTo(email, kosara);
                PovecajProdanuKolicinu(cookie);
                db.SaveChanges();
                return Json("succes", JsonRequestBehavior.AllowGet);
            }



        }


        public bool OduzmiKolicinu(string cookie)
        {
            var kolicina = db.Kosara.Where(x => x.Cookie.Equals(cookie)).FirstOrDefault();

            foreach (var item in kolicina.KosaraProizvod)
            {
                item.Proizvod.Kolicina -= item.Kolicina;
                if (item.Kolicina < 0)
                {
                    return false;
                }
            }
            db.SaveChanges();
            return true;
        }

        public void PovecajProdanuKolicinu(string cookie)
        {
            var kolicina = db.Kosara.Where(x => x.Cookie.Equals(cookie)).FirstOrDefault();
            foreach (var item in kolicina.KosaraProizvod)
            {
                item.Proizvod.ProdanaKolicina += item.Kolicina;
            }
            //db.SaveChanges();
        }

        /*
        public void IsprazniKosaricu(string cookie)
        {
            Kosara kosara = db.Kosara.Where(x => x.Cookie == cookie).SingleOrDefault();
            IEnumerable kosaraproizvod = db.KosaraProizvod.Where(x=> x.Kosara_ID==kosara.ID).AsEnumerable();

            foreach (var item in kosaraproizvod)
            {
                kosara.KosaraProizvod.Remove(item);
            }


            db.Kosara.Remove(kosara);
            db.SaveChanges();

        }*/
        /*
        public JsonResult Brojac(string cookie, int idProizvoda)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var kosara = db.Kosara.Where(x => x.Cookie == cookie).Select(x=> x.KosaraProizvod);
            var test = new
            {
                kosar=kosara
            };
            return Json(test, JsonRequestBehavior.AllowGet);
        }*/
        /*
       public JsonResult Provjeri(string cookiePersonalId)
       {
           db.Configuration.ProxyCreationEnabled = false;
           Kosara a = db.Kosara.Where(x => x.Cookie == cookiePersonalId).First();
           return Json(a,JsonRequestBehavior.AllowGet);
       }
       */

    }
}