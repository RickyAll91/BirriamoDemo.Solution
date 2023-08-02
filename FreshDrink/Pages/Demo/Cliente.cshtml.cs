using BirriamoDemoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshDrink.Pages.Demo
{
    public class ClienteModel : PageModel
    {
        public List<Clienti> ListaCliente { get; set; }
        public HttpClient Client = new()
        {
            BaseAddress = new Uri("https://localhost:7035")
        };
        public ClienteModel()
        {
            ListaCliente = new List<Clienti>();
        }
        public async Task<IActionResult> OnGet()
        {
            try 
            {
                ListaCliente = await Client.GetFromJsonAsync<List<Clienti>>("api/Clienti");
                return Page();
            } 
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
