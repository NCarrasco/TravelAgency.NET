namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TravelAgency.DAL.Util;
    using System.Web.Mvc;

    [Table("tOsoby")]
    [Bind(Include = "Imie,Nazwisko,NIP")]
    public partial class tOsoby : IUserWithAddress
    {
        public tOsoby()
        {
            tKlienciAtrakcje = new HashSet<tKlienciAtrakcje>();
            tKlienciAtrakcjeHistoria = new HashSet<tKlienciAtrakcjeHistoria>();
            tKlienciOferty = new HashSet<tKlienciOferty>();
            tKlienciOfertyHistoria = new HashSet<tKlienciOfertyHistoria>();
        }

        [Key]
        public int IDOsoby { get; set; }

        public int IDKlienta { get; set; }

        public int? IDAdresu { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(32)]
        public string Imie { get; set; }

        [Display(Name = "Surname", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Display(Name = "Employee", ResourceType = typeof(Strings))]
        public bool bPracownik { get; set; }

        [Display(Name = "NIP", ResourceType = typeof(Strings))]
        [StringLength(13)]
        public string NIP { get; set; }

        public virtual tAdresy tAdresy { get; set; }

        public virtual ICollection<tKlienciAtrakcje> tKlienciAtrakcje { get; set; }

        public virtual ICollection<tKlienciAtrakcjeHistoria> tKlienciAtrakcjeHistoria { get; set; }

        public virtual ICollection<tKlienciOferty> tKlienciOferty { get; set; }

        public virtual ICollection<tKlienciOfertyHistoria> tKlienciOfertyHistoria { get; set; }

        public virtual tKlient tKlient { get; set; }
    }
}
