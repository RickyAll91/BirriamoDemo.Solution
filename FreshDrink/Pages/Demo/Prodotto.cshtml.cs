using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshDrink.Pages.Demo
{
    public class ProdottoModel : PageModel
    {
        public List<Prodotto> ListaProdotti { get; set; }
        public HttpClient Client = new()
        {
            BaseAddress = new Uri("https://localhost:7035")
        };
        public ProdottoModel()
        {
            ListaProdotti = new List<Prodotto>();
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                ListaProdotti = await Client.GetFromJsonAsync<List<Prodotto>>("api/Prodotti");
                return Page();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
