using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Models
{
    public class Day
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
        public int? ReportId { get; set; }
        public Report Report { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
