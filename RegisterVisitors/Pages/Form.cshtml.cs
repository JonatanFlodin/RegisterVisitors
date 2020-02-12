using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterVisitors.Core;
using RegisterVisitors.Data;

namespace RegisterVisitors.Pages
{
    public class FormModel : PageModel
    {
        private readonly IVisitorData visitorData;

        [BindProperty]
        public Visitor Visitor { get; set; }

        public FormModel(IVisitorData visitorData)
        {
            this.visitorData = visitorData;
        }

        
        public IActionResult OnGet(int? visitorId)
        {
            if(visitorId.HasValue)
            {
                Visitor = visitorData.GetById(visitorId.Value);
            }
            else
            {
                Visitor = new Visitor();
            }
            if(Visitor == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            if(Visitor.Id > 0)
            {
                visitorData.Update(Visitor);
            }
            else
            {
                visitorData.Add(Visitor);
            }
            visitorData.Commit();
            return RedirectToPage("./Detail", new { visitorId = Visitor.Id });
        }
    }
}
