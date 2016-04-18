namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tAtrakcjeHistoria")]
    public partial class tAtrakcjeHistoria
    {
        public tAtrakcjeHistoria()
        {
            tKlienciAtrakcjeHistoria = new HashSet<tKlienciAtrakcjeHistoria>();
        }

        [Key]
        public int IDAtrakcjiUslugi { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwa { get; set; }

        public int iLiczbaOsob { get; set; }

        [Column(TypeName = "money")]
        public decimal mCena { get; set; }

        public int IDOferty { get; set; }

        [StringLength(4026)]
        public string Opis { get; set; }

        public virtual tHistoriaOfert tHistoriaOfert { get; set; }

        public virtual ICollection<tKlienciAtrakcjeHistoria> tKlienciAtrakcjeHistoria { get; set; }
    }
}
