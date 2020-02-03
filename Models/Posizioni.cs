using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace poligono.Models
{
    public class Posizioni
    {
        public int ID { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
    }
    public class PosizioniDB : DbContext
    {
        public DbSet<Posizioni> Posizioni { get; set; }
    }
}