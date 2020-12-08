using ComView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComViewAPI.Dto.Category
{
    public class CategoryCreateDto
    {
        [Required]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public ICollection<Product> Products { get; set; }
    }
}
