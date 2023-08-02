using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshDrink.Pages.Demo
{
    public class AgenteModel : PageModel
    {
        public List<Dipendenti> ListaDipendenti { get; set; }
        public HttpClient Client = new()
        {
            BaseAddress = new Uri("https://localhost:7035")
        };
        public AgenteModel()
        {
            ListaDipendenti = new List<Dipendenti>();
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                ListaDipendenti = await Client.GetFromJsonAsync<List<Dipendenti>>("api/Dipendenti");
                return Page();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
