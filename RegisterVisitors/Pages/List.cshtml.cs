using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using RegisterVisitors.Core;
using RegisterVisitors.Data;

namespace RegisterVisitors
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IVisitorData visitorData;

        public string Message { get; set; }
        public IEnumerable<Visitor> Visitors { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IVisitorData visitorData)
        {
            this.config = config;
            this.visitorData = visitorData;
        }
        public void OnGet()
        {
            Message = config["Message"];

            Visitors = visitorData.GetVisitorByName(SearchTerm);
            //Visitors = visitorData.GetVisitorByDate(DateTime.Now.ToString("yyy/MM/dd"));
        }
    }
}