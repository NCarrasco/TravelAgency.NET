namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TravelAgency.DAL.Util;

    [Table("tHistoriaOfert")]
    public partial class tHistoriaOfert
    {
        public tHistoriaOfert()
        {
            tAtrakcjeHistoria = new HashSet<tAtrakcjeHistoria>();
            tKlienciOfertyHistoria = new HashSet<tKlienciOfertyHistoria>();
        }

        [Key]
        public int IDOferty { get; set; }

        [Display(Name = "Departure", ResourceType = typeof(Strings))]
        public int bWyjazd { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Strings))]
        [Column(TypeName = "money")]
        public decimal mCena { get; set; }

        [Display(Name = "PersonCount", ResourceType = typeof(Strings))]
        public int iLiczbaOsob { get; set; }

        public int IDPanstwa { get; set; }

        [Display(Name = "City", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(128)]
        public string Miasto { get; set; }

        [Display(Name = "DeparturePlace", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(64)]
        public string MiejsceWyjazdu { get; set; }

        [Display(Name = "DayCount", ResourceType = typeof(Strings))]
        public int LiczbaDniTrwania { get; set; }

        [Display(Name = "DepartureDate", ResourceType = typeof(Strings))]
        public DateTime DataWyjazdu { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Strings))]
        [StringLength(4096)]
        public string Opis { get; set; }

        public virtual tPanstwa tPanstwa { get; set; }

        public virtual ICollection<tAtrakcjeHistoria> tAtrakcjeHistoria { get; set; }

        public virtual ICollection<tKlienciOfertyHistoria> tKlienciOfertyHistoria { get; set; }
    }
}
