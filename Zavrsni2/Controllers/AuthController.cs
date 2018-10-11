using System;
using System.Linq;
using System.Data;
using System.Web.Mvc;
using Zavrsni2.Models;
using System.Net;
using System.Web.Security;
using System.Net.Mail;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;


namespace Zavrsni2.Controllers
{
    public class AuthController : BaseController
    {
        // GET: Auth
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public JsonResult newLogin(string Email, string Password)
        {
            if (Email != null && Password != null)
            {
                
                var user = db.User.Where(x => x.Email == Email && x.Pass == Password).FirstOrDefault();
                if(user!=null)
                {
                    FormsAuthentication.SetAuthCookie(Email, true);
                    var CurrUser = db.User.Where(u => u.Email == Email).FirstOrDefault();
                    return Json("success", JsonRequestBehavior.AllowGet);

                }
                else
                {
                    FormsAuthentication.SignOut();
                    return Json("fail", JsonRequestBehavior.AllowGet);
                }
            }

            else
            {
                FormsAuthentication.SignOut();
                return Json("fail", JsonRequestBehavior.AllowGet);
            }

         
        }
        public JsonResult Register(string password,string email,string ime,string prezime,string br)
        {
            var korisnik = db.User.Any(x => x.Email == email);

            if(password!=null && email!=null)
            {
                if(korisnik==false)
                { 
                    var user = new User();
                    user.Email = email;
                    user.Pass = password;
                    user.Ime = ime;
                    user.Prezime = prezime;
                    user.Broj_mobitela = br;
                    user.ID_Uloga = 2;
                    db.User.Add(user);
                    db.SaveChanges();
                    newLogin(email, password);
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("fail", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("fail", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index","home");
        }
        public ActionResult neovlasteni_pristup()
        {

            return View();
        }
        //public ActionResult Profil()
        //{
        //    var user = User.Identity.Name;
            
        //    return View();
        //}

    }
    
}