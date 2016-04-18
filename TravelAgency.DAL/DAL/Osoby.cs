namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Osoby")]
    public partial class Osoby
    {
        [Key]
        public int IDOsoby { get; set; }

        [StringLength(32)]
        public string Imie { get; set; }

        [StringLength(50)]
        public string Nazwisko { get; set; }

        [StringLength(128)]
        public string Adres { get; set; }

        public int? Panstwo { get; set; }

        [StringLength(128)]
        public string Region { get; set; }

        [StringLength(64)]
        public string Miasto { get; set; }

        [StringLength(32)]
        public string Kod { get; set; }

        [StringLength(32)]
        public string Tel { get; set; }

        public virtual tPanstwa tPanstwa { get; set; }
    }
}
