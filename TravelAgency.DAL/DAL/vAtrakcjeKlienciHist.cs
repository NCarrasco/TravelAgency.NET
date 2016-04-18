namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vAtrakcjeKlienciHist")]
    public partial class vAtrakcjeKlienciHist
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

        [StringLength(4026)]
        public string Opis { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlienta { get; set; }

        [Column(Order = 6)]
        [StringLength(7)]
        public string SposobZaplaty { get; set; }

        [Column(Order = 7)]
        public DateTime DataZaplaty { get; set; }

        [Column(TypeName = "money")]
        public decimal? ZalpaconaKwota { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOsobyAtrakcji { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDKlientaOsoby { get; set; }
    }
}
