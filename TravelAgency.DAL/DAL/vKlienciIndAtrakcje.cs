namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vKlienciIndAtrakcje")]
    public partial class vKlienciIndAtrakcje
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAdresu { get; set; }

        [Column(Order = 1)]
        [StringLength(512)]
        public string Adres { get; set; }

        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Panstwo { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Region { get; set; }

        [Column(Order = 4)]
        public string Miasto { get; set; }

        [Column(Order = 5)]
        [StringLength(32)]
        public string Kod { get; set; }

        [Column(Order = 6)]
        [StringLength(32)]
        public string Telefon { get; set; }

        [StringLength(32)]
        public string Faks { get; set; }

        [Column(Order = 7)]
        [StringLength(32)]
        public string Imie { get; set; }

        [Column(Order = 8)]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Column(Order = 9)]
        public bool bPracownik { get; set; }


        [Column(Order = 10)]
        public bool bFirma { get; set; }

        [Column(Order = 11)]
        [StringLength(34)]
        public string haslo { get; set; }

        [Column(Order = 12)]
        [StringLength(64)]
        public string email { get; set; }

        [Key]
        [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAtrakcjiUslugi { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyAtrakcji { get; set; }

        [Column(Order = 16)]
        public DateTime DataRezerwacji { get; set; }

        [StringLength(1)]
        public string SposobZaplaty { get; set; }

        public DateTime? DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }

        [StringLength(13)]
        public string NIP { get; set; }
    }
}
