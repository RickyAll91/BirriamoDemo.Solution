namespace BirriamoDemoAPI.Models;

public partial class Sconti
{
    public int IdSconto { get; set; }

    public int IdProdotto { get; set; }

    public int? Quantità { get; set; }

    public double? PercentualeSconto { get; set; }

    public virtual ICollection<DettaglioOrdine> DettaglioOrdini { get; set; } = new List<DettaglioOrdine>();

    public virtual Prodotto IdProdottoNavigation { get; set; } = null!;
}
