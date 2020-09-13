using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Models
{
    public class Payment
    {
        public Payment(int id, string title, string description, double amount, DateTime dateTo)
        {
            Id = id;
            Title = title;
            Description = description;
            Amount = amount;
            DateTo = dateTo;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime DateTo { get; set; }
    }
}
