using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Dto
{
    public class ProductUpdateDto
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
