namespace TravelAgency.DAL.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext()
            : base("name=TravelAgencyContext")
        {
        }

        public virtual DbSet<Osoby> Osoby { get; set; }
        public virtual DbSet<tAdresy> tAdresy { get; set; }
        public virtual DbSet<tAtrakcjeHistoria> tAtrakcjeHistoria { get; set; }
        public virtual DbSet<tAtrakcjeUslugi> tAtrakcjeUslugi { get; set; }
        public virtual DbSet<tFirmy> tFirmy { get; set; }
        public virtual DbSet<tHistoriaOfert> tHistoriaOfert { get; set; }
        public virtual DbSet<tKlienciAtrakcje> tKlienciAtrakcje { get; set; }
        public virtual DbSet<tKlienciAtrakcjeHistoria> tKlienciAtrakcjeHistoria { get; set; }
        public virtual DbSet<tKlienciOferty> tKlienciOferty { get; set; }
        public virtual DbSet<tKlienciOfertyHistoria> tKlienciOfertyHistoria { get; set; }
        public virtual DbSet<tKlient> tKlient { get; set; }
        public virtual DbSet<tOferta> tOferta { get; set; }
        public virtual DbSet<tOsoby> tOsoby { get; set; }
        public virtual DbSet<tPanstwa> tPanstwa { get; set; }
        public virtual DbSet<vAtrakcjeHistoria> vAtrakcjeHistoria { get; set; }
        public virtual DbSet<vAtrakcjeKlienci> vAtrakcjeKlienci { get; set; }
        public virtual DbSet<vAtrakcjeKlienciHist> vAtrakcjeKlienciHist { get; set; }
        public virtual DbSet<vFirmyAtrakcje> vFirmyAtrakcje { get; set; }
        public virtual DbSet<vFirmyOferty> vFirmyOferty { get; set; }
        public virtual DbSet<vKlienciAtrakcje> vKlienciAtrakcje { get; set; }
        public virtual DbSet<vKlienciAtrakcjeOferty> vKlienciAtrakcjeOferty { get; set; }
        public virtual DbSet<vKlienciIndAtrakcje> vKlienciIndAtrakcje { get; set; }
        public virtual DbSet<vKlienciIndOferty> vKlienciIndOferty { get; set; }
        public virtual DbSet<vKlientOsobaAdres> vKlientOsobaAdres { get; set; }
        public virtual DbSet<vOfertyHistoria> vOfertyHistoria { get; set; }
        public virtual DbSet<vOfertyHistPanstwa> vOfertyHistPanstwa { get; set; }
        public virtual DbSet<vOfertyKlienci> vOfertyKlienci { get; set; }
        public virtual DbSet<vOfertyPanstwa> vOfertyPanstwa { get; set; }
        public virtual DbSet<vOsobyAtrakcje> vOsobyAtrakcje { get; set; }
        public virtual DbSet<vOsobyAtrakcjeHist> vOsobyAtrakcjeHist { get; set; }
        public virtual DbSet<vOsobyOferty> vOsobyOferty { get; set; }
        public virtual DbSet<vOsobyOfertyHist> vOsobyOfertyHist { get; set; }
        public virtual DbSet<vWszyscyKlienci> vWszyscyKlienci { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Osoby>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<Osoby>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<Osoby>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<Osoby>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<Osoby>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<Osoby>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<Osoby>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<tAdresy>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<tAdresy>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<tAdresy>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<tAdresy>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<tAdresy>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<tAdresy>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<tAdresy>()
                .HasMany(e => e.tFirmy)
                .WithRequired(e => e.tAdresy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tAtrakcjeHistoria>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<tAtrakcjeHistoria>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tAtrakcjeHistoria>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<tAtrakcjeHistoria>()
                .HasMany(e => e.tKlienciAtrakcjeHistoria)
                .WithRequired(e => e.tAtrakcjeHistoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tAtrakcjeUslugi>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<tAtrakcjeUslugi>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tAtrakcjeUslugi>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<tFirmy>()
                .Property(e => e.NazwaFirmy)
                .IsUnicode(false);

            modelBuilder.Entity<tFirmy>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tFirmy>()
                .Property(e => e.REGON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tHistoriaOfert>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tHistoriaOfert>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<tHistoriaOfert>()
                .Property(e => e.MiejsceWyjazdu)
                .IsUnicode(false);

            modelBuilder.Entity<tHistoriaOfert>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<tHistoriaOfert>()
                .HasMany(e => e.tAtrakcjeHistoria)
                .WithRequired(e => e.tHistoriaOfert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tHistoriaOfert>()
                .HasMany(e => e.tKlienciOfertyHistoria)
                .WithRequired(e => e.tHistoriaOfert)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tKlienciAtrakcje>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tKlienciAtrakcje>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tKlienciAtrakcjeHistoria>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tKlienciAtrakcjeHistoria>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tKlienciOferty>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tKlienciOferty>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tKlienciOfertyHistoria>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tKlienciOfertyHistoria>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tKlient>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tKlient>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<tKlient>()
                .HasMany(e => e.tFirmy)
                .WithRequired(e => e.tKlient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tKlient>()
                .HasMany(e => e.tKlienciAtrakcje)
                .WithRequired(e => e.tKlient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tKlient>()
                .HasMany(e => e.tKlienciAtrakcjeHistoria)
                .WithRequired(e => e.tKlient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tKlient>()
                .HasMany(e => e.tKlienciOferty)
                .WithRequired(e => e.tKlient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tKlient>()
                .HasMany(e => e.tOsoby)
                .WithRequired(e => e.tKlient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tOferta>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tOferta>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<tOferta>()
                .Property(e => e.MiejsceWyjazdu)
                .IsUnicode(false);

            modelBuilder.Entity<tOferta>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<tOsoby>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<tOsoby>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<tOsoby>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tOsoby>()
                .HasMany(e => e.tKlienciAtrakcje)
                .WithRequired(e => e.tOsoby)
                .HasForeignKey(e => e.IDOsobyAtrakcji)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tOsoby>()
                .HasMany(e => e.tKlienciAtrakcjeHistoria)
                .WithRequired(e => e.tOsoby)
                .HasForeignKey(e => e.IDOsobyAtrakcji)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tOsoby>()
                .HasMany(e => e.tKlienciOferty)
                .WithRequired(e => e.tOsoby)
                .HasForeignKey(e => e.IDOsobyImprezy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tOsoby>()
                .HasMany(e => e.tKlienciOfertyHistoria)
                .WithRequired(e => e.tOsoby)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tPanstwa>()
                .Property(e => e.NazwaPanstwa)
                .IsUnicode(false);

            modelBuilder.Entity<tPanstwa>()
                .HasMany(e => e.Osoby)
                .WithOptional(e => e.tPanstwa)
                .HasForeignKey(e => e.Panstwo);

            modelBuilder.Entity<tPanstwa>()
                .HasMany(e => e.tAdresy)
                .WithRequired(e => e.tPanstwa)
                .HasForeignKey(e => e.Panstwo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tPanstwa>()
                .HasMany(e => e.tOferta)
                .WithRequired(e => e.tPanstwa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.mCenaOferty)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.MiejsceWyjazdu)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.OpisOferty)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vAtrakcjeHistoria>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeKlienci>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeKlienci>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vAtrakcjeKlienci>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeKlienci>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeKlienci>()
                .Property(e => e.ZalpaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vAtrakcjeKlienciHist>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeKlienciHist>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vAtrakcjeKlienciHist>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeKlienciHist>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vAtrakcjeKlienciHist>()
                .Property(e => e.ZalpaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.NazwaFirmy)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyAtrakcje>()
                .Property(e => e.REGON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.NazwaFirmy)
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vFirmyOferty>()
                .Property(e => e.REGON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcje>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcjeOferty>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcjeOferty>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vKlienciAtrakcjeOferty>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcjeOferty>()
                .Property(e => e.ZaplaconaKwotaAtrakcji)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vKlienciAtrakcjeOferty>()
                .Property(e => e.SposobZaplatyAtrakcji)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcjeOferty>()
                .Property(e => e.SposobZaplatyOferty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciAtrakcjeOferty>()
                .Property(e => e.ZaplaconaKwotaOferty)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vKlienciIndAtrakcje>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlienciIndOferty>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vKlientOsobaAdres>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistoria>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOfertyHistoria>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistoria>()
                .Property(e => e.MiejsceWyjazdu)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistoria>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistoria>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistoria>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOfertyHistoria>()
                .Property(e => e.NazwaPanstwa)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistPanstwa>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOfertyHistPanstwa>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistPanstwa>()
                .Property(e => e.MiejsceWyjazdu)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistPanstwa>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyHistPanstwa>()
                .Property(e => e.NazwaPanstwa)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyKlienci>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOfertyKlienci>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyKlienci>()
                .Property(e => e.MiejsceWyjazdu)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyKlienci>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyKlienci>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyKlienci>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOfertyKlienci>()
                .Property(e => e.NazwaPanstwa)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyPanstwa>()
                .Property(e => e.mCena)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOfertyPanstwa>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyPanstwa>()
                .Property(e => e.MiejsceWyjazdu)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyPanstwa>()
                .Property(e => e.Opis)
                .IsUnicode(false);

            modelBuilder.Entity<vOfertyPanstwa>()
                .Property(e => e.NazwaPanstwa)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOsobyAtrakcje>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOsobyAtrakcjeHist>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOferty>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOferty>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOsobyOferty>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOferty>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOferty>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOferty>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOfertyHist>()
                .Property(e => e.SposobZaplaty)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOfertyHist>()
                .Property(e => e.ZaplaconaKwota)
                .HasPrecision(19, 4);

            modelBuilder.Entity<vOsobyOfertyHist>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOfertyHist>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOfertyHist>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vOsobyOfertyHist>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.haslo)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Imie)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Nazwisko)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.NIP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.REGON)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Adres)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Miasto)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Kod)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Telefon)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.Faks)
                .IsUnicode(false);

            modelBuilder.Entity<vWszyscyKlienci>()
                .Property(e => e.NazwaPanstwa)
                .IsUnicode(false);
        }
    }
}
