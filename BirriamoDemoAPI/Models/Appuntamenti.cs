namespace BirriamoDemoAPI.Models;

public partial class Appuntamenti
{
    public int Id { get; set; }

    public int IdDipendente { get; set; }

    public DateTime DataOra { get; set; }

    public string? Note { get; set; }

    public string? Indirizzo { get; set; }

    public string? NomeReferente { get; set; }

    public string? CognomeReferente { get; set; }

    public int? Votazione { get; set; }

    public int? IdCliente { get; set; }

    public virtual Clienti IdClienteNavigation { get; set; } = null!;

    public virtual Dipendenti IdDipendenteNavigation { get; set; } = null!;
}
