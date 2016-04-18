namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vFirmyOferty")]
    public partial class vFirmyOferty
    {
        [Column(Order = 0)]
        [StringLength(64)]
        public string email { get; set; }

        [Column(Order = 1)]
        [StringLength(34)]
        public string haslo { get; set; }

        [Column(Order = 2)]
        public bool bFirma { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAdresu { get; set; }

        [Column(Order = 4)]
        [StringLength(512)]
        public string Adres { get; set; }

        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Panstwo { get; set; }

        [Key]
        [Column(Order = 6)]
        public string Region { get; set; }

        [Column(Order = 7)]
        public string Miasto { get; set; }

        [Column(Order = 8)]
        [StringLength(32)]
        public string Kod { get; set; }

        [Column(Order = 9)]
        [StringLength(32)]
        public string Telefon { get; set; }

        [StringLength(32)]
        public string Faks { get; set; }

        [Column(Order = 10)]
        public string NazwaFirmy { get; set; }

        [Key]
        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOferty { get; set; }

        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyImprezy { get; set; }

        [Column(Order = 14)]
        public DateTime DataRezerwacji { get; set; }

        [StringLength(1)]
        public string SposobZaplaty { get; set; }

        public DateTime? DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDFirmy { get; set; }

        [Column(Order = 16)]
        [StringLength(13)]
        public string NIP { get; set; }

        [Column(Order = 17)]
        [StringLength(15)]
        public string REGON { get; set; }
    }
}
