using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterVisitors.Core;
using RegisterVisitors.Data;

namespace RegisterVisitors
{
    public class DetailModel : PageModel
    {
        private readonly IVisitorData visitorData;

        public Visitor Visitor { get; set; }

        public DetailModel(IVisitorData visitorData)
        {
            this.visitorData = visitorData;
        }
        public IActionResult OnGet(int visitorId)
        {
            Visitor = visitorData.GetById(visitorId);
            if(Visitor == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}