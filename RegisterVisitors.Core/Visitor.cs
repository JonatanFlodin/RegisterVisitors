using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegisterVisitors.Core
{
    public class Visitor
    {
        public Visitor()
        {
            Date = DateTime.Now.ToString("yyyy/MM/dd");
        }
        public int Id { get; set; }

        public string Date { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Namn")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Företag/Organisation")]
        public string Company { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Vem besöker du här idag?")]
        public string Visiting { get; set; }
    }
}
