namespace BirriamoDemoAPI.Models;

public partial class Ruoli
{
    public int Id { get; set; }

    public string Descrizione { get; set; } = null!;

    public virtual ICollection<Dipendenti> Dipendenti { get; set; } = new List<Dipendenti>();
}
