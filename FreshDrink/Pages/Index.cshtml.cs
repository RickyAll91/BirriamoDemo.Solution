using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace FreshDrink.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [Required(ErrorMessage = "Il campo User è obbligatorio.")]
        public string? User { get; set; }  

        [Required(ErrorMessage = "Il campo Password è obbligatorio.")]
        [MinLength(4, ErrorMessage = "La Password è troppo corta")]
        [MaxLength(8, ErrorMessage = "La Password è troppo lunga")]
        public string? Password { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string user, string password)
        {
            if (ModelState.IsValid && user == "admin@gmail.com" && password == "admin")
            {
                return RedirectToPage("/Demo/Cliente");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenziali non valide.");
            }
            return Page();
        }
    }
}