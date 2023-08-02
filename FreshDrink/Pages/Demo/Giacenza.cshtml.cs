using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshDrink.Pages.Demo
{
    public class GiacenzaModel : PageModel
    {
        public List<Giacenze> ListaGiacenza { get; set; }
        public HttpClient Client = new()
        {
            BaseAddress = new Uri("https://localhost:7035")
        };
        public GiacenzaModel()
        {
            ListaGiacenza = new List<Giacenze>();
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                ListaGiacenza = await Client.GetFromJsonAsync<List<Giacenze>>("api/Giacenze");
                return Page();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
