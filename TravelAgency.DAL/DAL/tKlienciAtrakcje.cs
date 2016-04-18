namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tKlienciAtrakcje")]
    public partial class tKlienciAtrakcje
    {
        public int IDKlienta { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAtrakcjiUslugi { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyAtrakcji { get; set; }

        public DateTime DataRezerwacji { get; set; }

        [StringLength(1)]
        public string SposobZaplaty { get; set; }

        public DateTime? DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }

        public virtual tAtrakcjeUslugi tAtrakcjeUslugi { get; set; }

        public virtual tKlient tKlient { get; set; }

        public virtual tOsoby tOsoby { get; set; }
    }
}
