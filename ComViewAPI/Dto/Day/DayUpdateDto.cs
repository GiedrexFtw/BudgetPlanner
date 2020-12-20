using ComView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Dto
{
    public class DayUpdateDto
    {

        [Required]
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
