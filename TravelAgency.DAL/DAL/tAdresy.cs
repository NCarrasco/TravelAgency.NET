namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
using System.Web.Mvc;
    using TravelAgency.DAL.Util;

    [Table("tAdresy")]
    [Bind(Include = "Adres,Region,Miasto,Kod,Telefon,Faks,tPanstwa,Panstwo")]
    public partial class tAdresy
    {
        public tAdresy()
        {
            tFirmy = new HashSet<tFirmy>();
            tOsoby = new HashSet<tOsoby>();
        }

        [Key]
        public int IDAdresu { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(512)]
        public string Adres { get; set; }

        [Display(Name="CountryName", ResourceType=typeof(Strings))]
        public int Panstwo { get; set; }

        [Required]
        [StringLength(128)]
        public string Region { get; set; }

        [Display(Name = "City", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(128)]
        public string Miasto { get; set; }

        [Display(Name = "ZipCode", ResourceType = typeof(Strings))]
        [Required]
        [StringLength(32)]
        public string Kod { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(Strings))]
        [DataType(DataType.PhoneNumber)]
        [Required]
        [RegularExpression("\\d[\\d-]+\\d")]
        [StringLength(32)]
        public string Telefon { get; set; }

        [Display(Name = "Fax", ResourceType = typeof(Strings))]
        [RegularExpression("\\d[\\d-]+\\d")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(32)]
        public string Faks { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(Strings))]
        public virtual tPanstwa tPanstwa { get; set; }

        public virtual ICollection<tFirmy> tFirmy { get; set; }

        public virtual ICollection<tOsoby> tOsoby { get; set; }
    }
}
