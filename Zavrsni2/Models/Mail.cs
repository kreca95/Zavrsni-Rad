using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zavrsni2.Models
{
    public class Mail
    {
        public static string Smtp { get; } = "smtp.gmail.com";
        public static int SmtpPort { get; } = 587;
        public static bool SmtpUseDefaultCredentials { get; } = true;
        public static bool EnableSsl { get;} = true;
        public static string MojMail { get;} = "mailzaskidanjenaposlu@gmail.com";
        public static string Sifra { get; } = "88360210q";
        public static string PrimalacMaila { get; }
        public static string Subject { get; } = "Pred racun";

        

    }
}