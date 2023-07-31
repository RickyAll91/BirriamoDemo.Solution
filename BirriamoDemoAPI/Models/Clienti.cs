namespace BirriamoDemoAPI.Models;

public partial class Clienti
{
    public int IdCliente { get; set; }

    public string PartitaIva { get; set; } = null!;

    public string RagioneSociale { get; set; } = null!;

    public string IndirizzoSedeGiuridica { get; set; } = null!;

    public string? Email { get; set; }

    public string? RecapitoTelefonico { get; set; }

    public virtual ICollection<Appuntamenti> Appuntamenti { get; set; } = new List<Appuntamenti>();

    public virtual ICollection<Ordine> Ordini { get; set; } = new List<Ordine>();
}
