using ComView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Dto
{
    public class DayCreateDto
    {

        [Required]
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public ICollection<Product> Products { get; set; }
    }
}
