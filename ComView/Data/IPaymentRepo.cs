using ComView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComView.Data
{
    interface IPaymentRepo
    {
        IEnumerable<Payment> GetPaymentList();
        Payment GetPaymentById(int id);


    }
}
