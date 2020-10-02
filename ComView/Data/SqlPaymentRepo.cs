using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public class SqlPaymentRepo : IPaymentRepo
    {
        private readonly PaymentContext _paymentContext;

        public SqlPaymentRepo(PaymentContext paymentContext)
        {
            _paymentContext = paymentContext;
        }
        public Payment GetPaymentById(int id)
        {
            return _paymentContext.Payments.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Payment> GetPaymentList()
        {
            return _paymentContext.Payments.ToList();
        }
    }
}
