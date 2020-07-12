using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCRUDWeb.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required(ErrorMessage ="Title of the Item is mandatory")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Description of the Item is mandatory")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Unit type is mandatory")]
        [Display(Name = "Unit Type")]
        public string UnitType { get; set; }
        [Required(ErrorMessage ="Rate of the Item is mandatory")]
        [RegularExpression("^[0-9]*$",ErrorMessage ="Enter correct rate value")]
        public string Rate { get; set; }
    }
}
