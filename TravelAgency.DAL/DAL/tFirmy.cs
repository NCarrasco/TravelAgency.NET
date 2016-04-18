namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("tFirmy")]
    [Bind(Include = "NazwaFirmy,NIP,REGON")]
    public partial class tFirmy : IUserWithAddress
    {
        [Key]
        public int IDFirmy { get; set; }

        [Required]
        [StringLength(128)]
        public string NazwaFirmy { get; set; }

        public int IDAdresu { get; set; }

        public int IDKlienta { get; set; }

        [Required]
        [StringLength(13)]
        public string NIP { get; set; }

        [Required]
        [StringLength(15)]
        public string REGON { get; set; }

        public virtual tAdresy tAdresy { get; set; }

        public virtual tKlient tKlient { get; set; }
    }
}
