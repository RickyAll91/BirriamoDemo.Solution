using Microsoft.EntityFrameworkCore;

namespace BirriamoDemoAPI.Models;

public partial class BirriamoDemoContext : DbContext
{
    public BirriamoDemoContext()
    {
    }

    public BirriamoDemoContext(DbContextOptions<BirriamoDemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appuntamenti> Appuntamenti { get; set; }

    public virtual DbSet<Clienti> Clienti { get; set; }

    public virtual DbSet<DettaglioOrdine> DettaglioOrdine { get; set; }

    public virtual DbSet<Dipendenti> Dipendenti { get; set; }

    public virtual DbSet<Giacenze> Giacenze { get; set; }

    public virtual DbSet<Ordine> Ordini { get; set; }

    public virtual DbSet<Prodotto> Prodotti { get; set; }

    public virtual DbSet<Ruoli> Ruoli { get; set; }

    public virtual DbSet<Sconti> Sconti { get; set; }

    public virtual DbSet<TipoOrdine> TipiOrdine { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BirriamoDemo");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appuntamenti>(entity =>
        {
            entity.ToTable("Appuntamenti");

            entity.Property(e => e.CognomeReferente).HasMaxLength(50);
            entity.Property(e => e.DataOra).HasColumnType("datetime");
            entity.Property(e => e.Indirizzo).HasMaxLength(50);
            entity.Property(e => e.NomeReferente).HasMaxLength(50);
            entity.Property(e => e.Note).HasMaxLength(50);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Appuntamenti)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appuntamenti_Clienti");

            entity.HasOne(d => d.IdDipendenteNavigation).WithMany(p => p.Appuntamenti)
                .HasForeignKey(d => d.IdDipendente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appuntamenti_Dipendenti");
        });

        modelBuilder.Entity<Clienti>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Clienti");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.IndirizzoSedeGiuridica).HasMaxLength(50);
            entity.Property(e => e.PartitaIva).HasMaxLength(50);
            entity.Property(e => e.RagioneSociale).HasMaxLength(50);
            entity.Property(e => e.RecapitoTelefonico).HasMaxLength(50);
        });

        modelBuilder.Entity<DettaglioOrdine>(entity =>
        {
            entity.ToTable("DettaglioOrdine");

            entity.Property(e => e.Importo).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdOrdineNavigation).WithMany(p => p.DettaglioOrdini)
                .HasForeignKey(d => d.IdOrdine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DettaglioOrdine_Ordine");

            entity.HasOne(d => d.IdProdottoNavigation).WithMany(p => p.DettaglioOrdini)
                .HasForeignKey(d => d.IdProdotto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DettaglioOrdine_Prodotto");

            entity.HasOne(d => d.IdScontoNavigation).WithMany(p => p.DettaglioOrdini)
                .HasForeignKey(d => d.IdSconto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DettaglioOrdine_Sconti");
        });

        modelBuilder.Entity<Dipendenti>(entity =>
        {
            entity.HasKey(e => e.Matricola);

            entity.ToTable("Dipendenti");

            entity.Property(e => e.Cognome).HasMaxLength(50);
            entity.Property(e => e.DataDiNascita).HasColumnType("date");
            entity.Property(e => e.Nome).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.IdRuoloNavigation).WithMany(p => p.Dipendenti)
                .HasForeignKey(d => d.IdRuolo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dipendenti_Ruoli");
        });

        modelBuilder.Entity<Giacenze>(entity =>
        {
            entity.ToTable("Giacenze");

            entity.Property(e => e.DataAggiornamentoQuantità).HasColumnType("date");

            entity.HasOne(d => d.IdProdottoNavigation).WithMany(p => p.Giacenze)
                .HasForeignKey(d => d.IdProdotto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Giacenze_Prodotto");
        });

        modelBuilder.Entity<Ordine>(entity =>
        {
            entity.HasKey(e => e.IdOrdine);

            entity.ToTable("Ordine");

            entity.Property(e => e.Data).HasColumnType("date");
            entity.Property(e => e.ImportoTotale).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ordini)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordine_Clienti");

            entity.HasOne(d => d.IdDipendenteNavigation).WithMany(p => p.Ordini)
                .HasForeignKey(d => d.IdDipendente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordine_Dipendenti");

            entity.HasOne(d => d.IdTipoOrdineNavigation).WithMany(p => p.Ordini)
                .HasForeignKey(d => d.IdTipoOrdine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ordine_TipoOrdine");
        });

        modelBuilder.Entity<Prodotto>(entity =>
        {
            entity.ToTable("Prodotto");

            entity.Property(e => e.Descrizione).HasMaxLength(50);
            entity.Property(e => e.Prezzo).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Ruoli>(entity =>
        {
            entity.ToTable("Ruoli");

            entity.Property(e => e.Descrizione).HasMaxLength(50);
        });

        modelBuilder.Entity<Sconti>(entity =>
        {
            entity.HasKey(e => e.IdSconto);

            entity.ToTable("Sconti");

            entity.HasOne(d => d.IdProdottoNavigation).WithMany(p => p.Sconti)
                .HasForeignKey(d => d.IdProdotto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sconti_Prodotto");
        });

        modelBuilder.Entity<TipoOrdine>(entity =>
        {
            entity.HasKey(e => e.IdTipo);

            entity.ToTable("TipoOrdine");

            entity.Property(e => e.Descrizione).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
