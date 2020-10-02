using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
        public DateTime DateTo { get; set; }
        public Payment(int id, string title, string description, double amount, DateTime dateTo)
        {
            Id = id;
            Title = title;
            Description = description;
            Amount = amount;
            DateTo = dateTo;
        } 
    }
}
