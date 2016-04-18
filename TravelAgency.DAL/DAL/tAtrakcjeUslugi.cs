namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using TravelAgency.DAL.Util;

    [Table("tAtrakcjeUslugi")]
    public partial class tAtrakcjeUslugi
    {
        public tAtrakcjeUslugi()
        {
            tKlienciAtrakcje = new HashSet<tKlienciAtrakcje>();
        }

        [Key]
        public int IDAtrakcjiUslugi { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(50)]
        public string Nazwa { get; set; }

        [Display(Name="PersonCount", ResourceType=typeof(Strings))]
        public int iLiczbaOsob { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Strings))]
        [Column(TypeName = "money")]
        public decimal mCena { get; set; }

        public int IDOferty { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Strings))]
        [StringLength(4096)]
        public string Opis { get; set; }

        public virtual tOferta tOferta { get; set; }

        public virtual ICollection<tKlienciAtrakcje> tKlienciAtrakcje { get; set; }
    }
}
