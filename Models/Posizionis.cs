namespace poligono.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Posizionis
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Lat { get; set; }

        [Required]
        [StringLength(50)]
        public string Lon { get; set; }
    }
}
