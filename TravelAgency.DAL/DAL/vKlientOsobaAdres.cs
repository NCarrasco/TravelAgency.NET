namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vKlientOsobaAdres
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsoby { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        public int? IDAdresu { get; set; }

        [Column(Order = 2)]
        [StringLength(32)]
        public string Imie { get; set; }

        [Column(Order = 3)]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Column(Order = 4)]
        public bool bPracownik { get; set; }

        [StringLength(13)]
        public string NIP { get; set; }

        [StringLength(512)]
        public string Adres { get; set; }

        public int? Panstwo { get; set; }

        [StringLength(128)]
        public string Region { get; set; }

        [StringLength(128)]
        public string Miasto { get; set; }

        [StringLength(32)]
        public string Kod { get; set; }

        [Column(Order = 5)]
        [StringLength(64)]
        public string email { get; set; }

        [Column(Order = 6)]
        [StringLength(34)]
        public string haslo { get; set; }

        [Column(Order = 7)]
        public bool bFirma { get; set; }

        [StringLength(32)]
        public string Telefon { get; set; }

        [StringLength(32)]
        public string Faks { get; set; }
    }
}
