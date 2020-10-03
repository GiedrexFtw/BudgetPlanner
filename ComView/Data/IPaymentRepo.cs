using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public interface IPaymentRepo
    {
        IEnumerable<Payment> GetPaymentList();
        Payment GetPaymentById(int id);
        void CreatePayment(Payment payment);
        bool SaveChanges();

    }
}
