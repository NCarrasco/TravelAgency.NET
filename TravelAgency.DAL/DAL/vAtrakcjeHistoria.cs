namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vAtrakcjeHistoria")]
    public partial class vAtrakcjeHistoria
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyAtrakcji { get; set; }

        [Column(Order = 2)]
        [StringLength(7)]
        public string SposobZaplaty { get; set; }

        [Column(Order = 3)]
        public DateTime DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZaplaconaKwota { get; set; }

        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bWyjazd { get; set; }

        [Column(Order = 5, TypeName = "money")]
        public decimal mCenaOferty { get; set; }

        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iLiczbaOsobOferty { get; set; }

        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPanstwa { get; set; }

        [Column(Order = 8)]
        public string Miasto { get; set; }

        [Column(Order = 9)]
        [StringLength(64)]
        public string MiejsceWyjazdu { get; set; }

        [Column(Order = 10)]
        public DateTime DataWyjazdu { get; set; }

        [StringLength(4096)]
        public string OpisOferty { get; set; }

        [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LiczbaDniTrwania { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDAtrakcjiUslugi { get; set; }

        [Column(Order = 13)]
        [StringLength(50)]
        public string Nazwa { get; set; }

        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iLiczbaOsob { get; set; }

        [Column(Order = 15, TypeName = "money")]
        public decimal mCena { get; set; }

        [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOferty { get; set; }

        [StringLength(4026)]
        public string Opis { get; set; }
    }
}
