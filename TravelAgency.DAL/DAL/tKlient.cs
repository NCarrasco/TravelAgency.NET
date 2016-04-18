namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tKlient")]
    public partial class tKlient
    {
        public tKlient()
        {
            tFirmy = new HashSet<tFirmy>();
            tKlienciAtrakcje = new HashSet<tKlienciAtrakcje>();
            tKlienciAtrakcjeHistoria = new HashSet<tKlienciAtrakcjeHistoria>();
            tKlienciOferty = new HashSet<tKlienciOferty>();
            tOsoby = new HashSet<tOsoby>();
        }

        [Key]
        public int IDKlienta { get; set; }

        [Required]
        [StringLength(64)]
        public string email { get; set; }

        [Required]
        [StringLength(34)]
        public string haslo { get; set; }

        public bool bFirma { get; set; }

        public virtual ICollection<tFirmy> tFirmy { get; set; }

        public virtual ICollection<tKlienciAtrakcje> tKlienciAtrakcje { get; set; }

        public virtual ICollection<tKlienciAtrakcjeHistoria> tKlienciAtrakcjeHistoria { get; set; }

        public virtual ICollection<tKlienciOferty> tKlienciOferty { get; set; }

        public virtual ICollection<tOsoby> tOsoby { get; set; }
    }
}
