using ComView.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public class PaymentContext :DbContext
    {
        public DbSet<Payment> Payments { get; set; }

        public PaymentContext(DbContextOptions<PaymentContext> options):base(options)
        {

        }
    }
}
