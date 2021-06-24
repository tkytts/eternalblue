using BlueIsForever.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace BlueIsForever.Pages
{
    [ValidateAntiForgeryToken(Order = 1000)]
    public class IndexModel : PageModel
    {
        private readonly string _password;
        
        public IndexModel(IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new System.ArgumentNullException(nameof(configuration));
            }

            _password = configuration["FirstPassword"];
            Password = ConvertHint(_password);
        }

        private string ConvertHint(string password)
        {
            var stringBuilder = new StringBuilder();
            foreach (var character in password)
            {
                var asciiValue = (int)character;

                stringBuilder.Append($"{asciiValue} ");
            }

            return stringBuilder.ToString().Trim();
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public string Pass { get; set; }
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (Pass == _password)
                return Redirect("./SecondPassword");
            else
                ModelState.AddModelError(nameof(Pass), "Incorrect password");
            
            return Page();
        }
    }
}
