using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haliSahaRezervasyon.Entity
{
    class Tarihler
    {
        [Key]
        public int TarihId { get; set; }
        public DateTime Tarih { get; set; }
        public Saatler Saat { get; set; }

        public Tarihler(DateTime tarih)
        {
            this.Tarih = tarih;
        }

    }
}
