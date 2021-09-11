using Microsoft.AspNetCore.Http;
using payment_provider_adapter.CustomResponses;
using payment_provider_adapter.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace payment_provider_integration.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<ICustomResponse> CreatePayment(PaymentDetails entity);
        Task<ICustomResponse> ConfirmPayment(ConfirmDetails entity);
        Task<ICustomResponse> GetPaymentStatus(string transaction_id);
    }
}
