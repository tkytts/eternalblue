using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace BlueIsForever.Pages
{
    public class SecondPasswordModel : PageModel
    {
        private readonly string _password;

        public SecondPasswordModel(IConfiguration configuration)
        {
            _password = configuration["SecondPassword"];
        }

        [BindProperty]
        public string Pass { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Pass == _password)
                return Redirect("./Success");
            else
                ModelState.AddModelError(nameof(Pass), "Incorrect password");

            return Page();
        }
    }
}
