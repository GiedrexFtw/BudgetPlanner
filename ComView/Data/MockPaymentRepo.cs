using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    public class MockPaymentRepo : IPaymentRepo
    {
        public Payment GetPaymentById(int id)
        {
            return new Payment(1, "sometext", "somedesc", 22.5, DateTime.Now);
        }

        public IEnumerable<Payment> GetPaymentList()
        {
            return new List<Payment> {
                new Payment( 1,  "sometext1",  "somedesc1",  10,  DateTime.Now),
                new Payment( 2,  "sometext2",  "somedesc2",  20,  DateTime.Now.AddDays(1)),
                new Payment( 3,  "sometext3",  "somedesc3",  30,  DateTime.Now.AddDays(2))
            };
        }
    }
}
