using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Zavrsni2.Models;

namespace Zavrsni2.Moje_klase
{
    public static class SendMail
    {
        public static void SendMailTo(string mail, Kosara kosara)
        {
            if (IsValidEmail(mail))
            {
                WebMail.SmtpServer = Mail.Smtp;
                WebMail.SmtpPort = Mail.SmtpPort;
                WebMail.SmtpUseDefaultCredentials = Mail.SmtpUseDefaultCredentials;
                WebMail.EnableSsl = Mail.EnableSsl;
                WebMail.UserName = Mail.MojMail;
                WebMail.Password = Mail.Sifra;
                WebMail.From = mail;
                WebMail.Send(mail, Mail.Subject, TekstMaila(kosara));
            }
            
        }

        public static string TekstMaila(Kosara kosara)
        {
            string proizvodi = " ";
            foreach (var item in kosara.KosaraProizvod)
            {
                proizvodi += "<br>Naziv proizvoda: " + item.Proizvod.Ime + ", količina: " + item.Kolicina + "<br>";
            }

            string sadrzaj = $"ID vase kupnje je {kosara.ID}, kupnja je izvrsena online ({kosara.Datum}) i sadrzi sljedeće artikle: " +
                $" { proizvodi}" +
                $" Saldo: {kosara.KosaraProizvod.Sum(x => x.Kolicina * x.Proizvod.Cijena)}";


            return sadrzaj;
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }

}