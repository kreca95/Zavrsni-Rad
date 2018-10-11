using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zavrsni2.Models
{
    public class Statistika
    {
        public List<Proizvod> Najprodavaniji { get; set; }
        public List<Proizvod> Najneprodavaniji { get; set; }
    }
}