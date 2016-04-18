namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vOfertyHistPanstwa")]
    public partial class vOfertyHistPanstwa
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDOferty { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bWyjazd { get; set; }

        [Column(Order = 2, TypeName = "money")]
        public decimal mCena { get; set; }

        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int iLiczbaOsob { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPanstwa { get; set; }

        [Column(Order = 5)]
        public string Miasto { get; set; }

        [Column(Order = 6)]
        [StringLength(64)]
        public string MiejsceWyjazdu { get; set; }

        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LiczbaDniTrwania { get; set; }

        [Column(Order = 8)]
        public DateTime DataWyjazdu { get; set; }

        [StringLength(4096)]
        public string Opis { get; set; }

        [Column(Order = 9)]
        public string NazwaPanstwa { get; set; }

        public int? LiczbaAtrakcji { get; set; }
    }
}
