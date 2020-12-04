using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public ICollection<Day> Days { get; set; }
        [Required]
        public bool IsExportable { get; set; }
    }
}
