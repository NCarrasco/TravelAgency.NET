namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vKlienciAtrakcjeOferty")]
    public partial class vKlienciAtrakcjeOferty
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAtrakcjiUslugi { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Nazwa { get; set; }

        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iLiczbaOsob { get; set; }

        [Column(Order = 3, TypeName = "money")]
        public decimal mCena { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOferty { get; set; }

        [StringLength(4096)]
        public string Opis { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyAtrakcji { get; set; }

        [Column(Order = 7)]
        public DateTime DataRezerwacjiAtrakcji { get; set; }

        [Column(Order = 8)]
        public DateTime DataRezerwacjiOferty { get; set; }

        public DateTime? DataZaplatyAtrakcji { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwotaAtrakcji { get; set; }

        [StringLength(1)]
        public string SposobZaplatyAtrakcji { get; set; }

        [StringLength(1)]
        public string SposobZaplatyOferty { get; set; }

        public DateTime? DataZaplatyOferty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwotaOferty { get; set; }
    }
}
