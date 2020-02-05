namespace poligono.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Posizioni : DbContext
    {
        public Posizioni()
            : base("name=Posizioni")
        {
        }

        public virtual DbSet<Posizionis> Posizionis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
