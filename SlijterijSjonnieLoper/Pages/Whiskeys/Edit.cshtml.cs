using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SlijterijSjonnieLoper.Core;
using SlijterijSjonnieLoper.Data;

namespace SlijterijSjonnieLoper.Pages.Whiskeys
{
    public class EditModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;
        public Whiskey Whiskey { get; set; }
        public EditModel(IWhiskeyData whiskeyData)
        {
            this.whiskeyData = whiskeyData;
        }
        public IActionResult OnGet(int whiskeyId)
        {
            Whiskey = whiskeyData.GetById(whiskeyId);
            if (Whiskey == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
