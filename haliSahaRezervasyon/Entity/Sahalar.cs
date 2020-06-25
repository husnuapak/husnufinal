using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haliSahaRezervasyon.Entity
{
    class Sahalar
    {
      [Key] public int SahaId { get; set; }
        public string SahaIsim { get; set; }
        public int Fiyat { get; set; }
        public  string Adres { get; set; }
        public bool SahaDurum { get; set; }
        public int SahaKisi { get; set; }
    }
}
