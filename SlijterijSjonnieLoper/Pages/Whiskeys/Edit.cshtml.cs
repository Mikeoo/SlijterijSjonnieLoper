using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SlijterijSjonnieLoper.Core;
using SlijterijSjonnieLoper.Data;

namespace SlijterijSjonnieLoper.Pages.Whiskeys
{
    public class EditModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Whiskey Whiskey { get; set; }
        public IEnumerable<SelectListItem> WhiskeyBrands { get; set; }
        public IEnumerable<SelectListItem> WhiskeyTypes { get; set; }
        public IEnumerable<SelectListItem> WhiskeyArea { get; set; }
        public EditModel(IWhiskeyData whiskeyData, 
                         IHtmlHelper htmlHelper)
        {
            this.whiskeyData = whiskeyData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? whiskeyId)
        {
            WhiskeyTypes = htmlHelper.GetEnumSelectList<WhiskeyType>();
            WhiskeyBrands = htmlHelper.GetEnumSelectList<WhiskeyBrand>();
            WhiskeyArea = htmlHelper.GetEnumSelectList<WhiskeyArea>();
            if (whiskeyId.HasValue)
            {
                Whiskey = whiskeyData.GetById(whiskeyId.Value);
            }
            else
            {
                Whiskey = new Whiskey();
            }
            if (Whiskey == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                WhiskeyTypes = htmlHelper.GetEnumSelectList<WhiskeyType>();
                WhiskeyBrands = htmlHelper.GetEnumSelectList<WhiskeyBrand>();
                WhiskeyArea = htmlHelper.GetEnumSelectList<WhiskeyArea>();
                return Page();               
            }
            if(Whiskey.Id >0)
            {
                whiskeyData.Update(Whiskey);
            }
            else
            { 
                whiskeyData.Add(Whiskey);
            }
            whiskeyData.Commit();
            TempData["Message"] = "Whiskey saved!";
            return RedirectToPage("./Detail", new { whiskeyId = Whiskey.Id });

        }
    }
}
