using ComView.Models;
using ComViewAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ComView.Dto
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int DayId { get; set; }
        public DateTime DayDate { get; set; }
    }
}
