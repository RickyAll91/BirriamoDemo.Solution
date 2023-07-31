namespace BirriamoDemoAPI.Models;

public partial class DettaglioOrdine
{
    public int Id { get; set; }

    public int IdOrdine { get; set; }

    public int IdProdotto { get; set; }

    public int Quantità { get; set; }

    public decimal Importo { get; set; }

    public int? IdSconto { get; set; }

    public virtual Ordine IdOrdineNavigation { get; set; } = null!;

    public virtual Prodotto IdProdottoNavigation { get; set; } = null!;

    public virtual Sconti IdScontoNavigation { get; set; } = null!;
}
