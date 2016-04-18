namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vOsobyAtrakcjeHist")]
    public partial class vOsobyAtrakcjeHist
    {
        public int? IDAdresu { get; set; }

        [StringLength(512)]
        public string Adres { get; set; }

        public int? Panstwo { get; set; }

        [StringLength(128)]
        public string Region { get; set; }

        [StringLength(128)]
        public string Miasto { get; set; }

        [StringLength(32)]
        public string Kod { get; set; }

        [StringLength(32)]
        public string Telefon { get; set; }

        [StringLength(32)]
        public string Faks { get; set; }

        [Column(Order = 0)]
        [StringLength(32)]
        public string Imie { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Column(Order = 2)]
        public bool bPracownik { get; set; }

        [Column(Order = 3)]
        public bool bFirma { get; set; }

        [Column(Order = 4)]
        [StringLength(34)]
        public string haslo { get; set; }

        [Column(Order = 5)]
        [StringLength(64)]
        public string email { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAtrakcjiUslugi { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyAtrakcji { get; set; }

        [Column(Order = 9)]
        [StringLength(7)]
        public string SposobZaplaty { get; set; }

        [Column(Order = 10)]
        public DateTime DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }

        [StringLength(13)]
        public string NIP { get; set; }
    }
}
