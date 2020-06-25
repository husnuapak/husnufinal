using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace haliSahaRezervasyon.Entity
{
    class Context:DbContext
    {
        public DbSet<Sahalar> Sahalars { get; set;  }
        public DbSet<Rezervasyon> Rezervasyons { get; set; }
        public DbSet<Saatler> Saatlers { get; set; }
        public DbSet<Tarihler> Tarihlers { get; set; }
       

    }
}
