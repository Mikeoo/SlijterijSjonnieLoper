using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using SlijterijSjonnieLoper.Core;
using SlijterijSjonnieLoper.Data;

namespace SlijterijSjonnieLoper.Pages.Whiskeys
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWhiskeyData whiskeyData;
      
        public string Message { get; set; }
        public IEnumerable<Whiskey> Whiskeys { get; set; }

        [BindProperty(SupportsGet = true )]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                         IWhiskeyData whiskeyData)
        {
            this.config = config;
            this.whiskeyData = whiskeyData;
        }
        public void OnGet(string searchTerm)
        { 
            Whiskeys = whiskeyData.GetWhiskeysByName(SearchTerm);
        }
    } 
}
