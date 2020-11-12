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
    public class DeleteModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;
        public Whiskey Whiskey { get; set; }

        public DeleteModel(IWhiskeyData whiskeyData)
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

        public IActionResult OnPost(int whiskeyId)
        {
            var whiskey = whiskeyData.Delete(whiskeyId);
            whiskeyData.Commit();
            if(whiskey ==null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{whiskey.Name} deleted";
            return RedirectToPage("./List");

        }
    }
}
