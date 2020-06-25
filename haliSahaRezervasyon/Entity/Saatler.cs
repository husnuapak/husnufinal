using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haliSahaRezervasyon.Entity
{
    class Saatler
    {
        [Key]
        public int SaatId { get; set; }
        public string Saat { get; set; }
        public bool SaatDurum { get; set; }


      public  Saatler(string saat)
        {
            this.Saat = saat;
        }
        public Saatler()
        {
        }
    }
}
