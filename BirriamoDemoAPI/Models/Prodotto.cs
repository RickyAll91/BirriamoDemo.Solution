namespace BirriamoDemoAPI.Models;

public partial class Prodotto
{
    public int Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public decimal Prezzo { get; set; }

    public double? Capacità { get; set; }

    public double? Gradazione { get; set; }

    public virtual ICollection<DettaglioOrdine> DettaglioOrdini { get; set; } = new List<DettaglioOrdine>();

    public virtual ICollection<Giacenze> Giacenze { get; set; } = new List<Giacenze>();

    public virtual ICollection<Sconti> Sconti { get; set; } = new List<Sconti>();
}
