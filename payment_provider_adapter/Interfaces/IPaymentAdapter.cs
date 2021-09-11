using payment_provider_adapter.CustomResponses;
using payment_provider_adapter.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace payment_provider_adapter.Interfaces
{
    public interface IPaymentAdapter
    {
        Task<ICustomResponse> CreatePayment(PaymentDetails entity);
        Task<ICustomResponse> ConfirmPayment(ConfirmDetails entity);
        Task<ICustomResponse> GetPaymentStatus(string transaction_id);
    }
}
