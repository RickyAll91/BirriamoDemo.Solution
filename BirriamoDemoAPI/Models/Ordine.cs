namespace BirriamoDemoAPI.Models;

public partial class Ordine
{
    public int IdOrdine { get; set; }

    public int IdDipendente { get; set; }

    public int IdCliente { get; set; }

    public DateTime? Data { get; set; }

    public decimal ImportoTotale { get; set; }

    public int IdTipoOrdine { get; set; }

    public virtual ICollection<DettaglioOrdine> DettaglioOrdini { get; set; } = new List<DettaglioOrdine>();

    public virtual Clienti IdClienteNavigation { get; set; } = null!;

    public virtual Dipendenti IdDipendenteNavigation { get; set; } = null!;

    public virtual TipoOrdine IdTipoOrdineNavigation { get; set; } = null!;
}
