using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haliSahaRezervasyon.Entity
{
    class Rezervasyon
    {
        [Key] public int RezervasyonId { get; set; }
        public int SahaId { get; set; }
        public DateTime Tarih { get; set; }
        public string RezervasyonSaat { get; set; }
        public string Notes { get; set; }
        public Boolean PayCheck { get; set; }
    }
}
