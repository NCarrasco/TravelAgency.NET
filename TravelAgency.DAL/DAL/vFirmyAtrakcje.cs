namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vFirmyAtrakcje")]
    public partial class vFirmyAtrakcje
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAtrakcjiUslugi { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyAtrakcji { get; set; }

        [Column(Order = 3)]
        public DateTime DataRezerwacji { get; set; }

        [StringLength(1)]
        public string SposobZaplaty { get; set; }

        public DateTime? DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }


        [Column(Order = 4)]
        [StringLength(64)]
        public string email { get; set; }

        [Column(Order = 5)]
        [StringLength(34)]
        public string haslo { get; set; }

        [Column(Order = 6)]
        public bool bFirma { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDFirmy { get; set; }

        [Column(Order = 8)]
        public string NazwaFirmy { get; set; }

        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAdresu { get; set; }

        [Column(Order = 10)]
        [StringLength(512)]
        public string Adres { get; set; }

        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Panstwo { get; set; }

        [Column(Order = 12)]
        public string Region { get; set; }

        [Column(Order = 13)]
        public string Miasto { get; set; }

        [Column(Order = 14)]
        [StringLength(32)]
        public string Kod { get; set; }

        [Column(Order = 15)]
        [StringLength(32)]
        public string Telefon { get; set; }

        [StringLength(32)]
        public string Faks { get; set; }

        [Column(Order = 16)]
        [StringLength(13)]
        public string NIP { get; set; }
        [Column(Order = 17)]
        [StringLength(15)]
        public string REGON { get; set; }
    }
}
