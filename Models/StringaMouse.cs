using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace poligono.Models
{
    public partial class StringaMouse : DbContext
    {
        public StringaMouse()
            : base("name=StringaMouse")
        {
        }

        public virtual DbSet<StringaMouse> StringheMouse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}