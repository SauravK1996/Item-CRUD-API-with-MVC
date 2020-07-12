using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
    

namespace ItemAPI.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UnitType { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter correct rate value")]
        public string Rate { get; set; }
       
    }
}
