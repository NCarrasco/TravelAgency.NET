namespace TravelAgency.DAL.DAL
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Web.Mvc;
using TravelAgency.DAL.Util;

    [Table("tPanstwa")]
    public partial class tPanstwa
    {
        public tPanstwa()
        {
            Osoby = new HashSet<Osoby>();
            tAdresy = new HashSet<tAdresy>();
            tOferta = new HashSet<tOferta>();
        }

        [Key]
        public int IDPanstwa { get; set; }

        [Display(Name="CountryName", ResourceType=typeof(Strings))]
        [Required]
        [StringLength(128)]
        public string NazwaPanstwa { get; set; }

        public virtual ICollection<Osoby> Osoby { get; set; }

        public virtual ICollection<tAdresy> tAdresy { get; set; }

        public virtual ICollection<tOferta> tOferta { get; set; }
    

private static object Include(string p)
{
 	throw new NotImplementedException();
}}
}
