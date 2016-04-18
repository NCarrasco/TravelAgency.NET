namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vOsobyOferty")]
    public partial class vOsobyOferty
    {
        [Column(Order = 0)]
        public DateTime DataRezerwacji { get; set; }

        [StringLength(1)]
        public string SposobZaplaty { get; set; }

        public DateTime? DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOferty { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlientaRezerwacji { get; set; }

        [Column(Order = 3)]
        [StringLength(64)]
        public string email { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsoby { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlientaOsoby { get; set; }

        public int? IDAdresu { get; set; }

        [Column(Order = 6)]
        [StringLength(32)]
        public string Imie { get; set; }

        [Column(Order = 7)]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Column(Order = 8)]
        public bool bPracownik { get; set; }

        [StringLength(13)]
        public string NIP { get; set; }
    }
}
