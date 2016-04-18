namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vOsobyOfertyHist")]
    public partial class vOsobyOfertyHist
    {
        [Column(Order = 0)]
        [StringLength(7)]
        public string SposobZaplaty { get; set; }

        [Column(Order = 1)]
        public DateTime DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOferty { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlientaRezerwacji { get; set; }

        [Column(Order = 4)]
        [StringLength(64)]
        public string email { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsoby { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlientaOsoby { get; set; }

        public int? IDAdresu { get; set; }

        [Column(Order = 7)]
        [StringLength(32)]
        public string Imie { get; set; }

        [Column(Order = 8)]
        [StringLength(50)]
        public string Nazwisko { get; set; }

        [Column(Order = 9)]
        public bool bPracownik { get; set; }

        [StringLength(13)]
        public string NIP { get; set; }
    }
}
