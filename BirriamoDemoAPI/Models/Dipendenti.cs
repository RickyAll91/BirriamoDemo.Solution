namespace BirriamoDemoAPI.Models;

public partial class Dipendenti
{
    public int Matricola { get; set; }

    public string? Nome { get; set; }

    public string? Cognome { get; set; }

    public DateTime? DataDiNascita { get; set; }

    public int IdRuolo { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Appuntamenti> Appuntamenti { get; set; } = new List<Appuntamenti>();

    public virtual Ruoli IdRuoloNavigation { get; set; } = null!;

    public virtual ICollection<Ordine> Ordini { get; set; } = new List<Ordine>();
}
