namespace BirriamoDemoAPI.Models;

public partial class Giacenze
{
    public int Id { get; set; }

    public int IdProdotto { get; set; }

    public int Quantità { get; set; }

    public DateTime? DataAggiornamentoQuantità { get; set; }

    public virtual Prodotto IdProdottoNavigation { get; set; } = null!;
}
