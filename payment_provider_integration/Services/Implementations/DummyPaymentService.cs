using Microsoft.AspNetCore.Http;
using payment_provider_adapter.CustomResponses;
using payment_provider_adapter.Entities;
using payment_provider_adapter.Interfaces;
using payment_provider_integration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace payment_provider_integration.Services.Implementations
{
    public class DummyPaymentService : IDummyPaymentService
    {
        private readonly IDummyPaymentAdapter _paymentAdapter;

        public DummyPaymentService(IDummyPaymentAdapter paymentAdapter)
        {
            _paymentAdapter = paymentAdapter;
        }

        public async Task<ICustomResponse> CreatePayment(PaymentDetails entity)
        {
            var response = await _paymentAdapter.CreatePayment(entity);

            return response;
        }

        public async Task<ICustomResponse> ConfirmPayment(ConfirmDetails entity)
        {
            var response = await _paymentAdapter.ConfirmPayment(entity);

            return response;
        }

        public async Task<ICustomResponse> GetPaymentStatus(string transaction_id)
        {
            var response = await _paymentAdapter.GetPaymentStatus(transaction_id);

            return response;
        }
    }
}
