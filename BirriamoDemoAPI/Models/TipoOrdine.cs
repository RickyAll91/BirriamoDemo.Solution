namespace BirriamoDemoAPI.Models;

public partial class TipoOrdine
{
    public int IdTipo { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<Ordine> Ordini { get; set; } = new List<Ordine>();
}
