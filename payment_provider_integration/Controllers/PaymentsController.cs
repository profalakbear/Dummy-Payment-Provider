using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using payment_provider_adapter.CustomResponses;
using payment_provider_adapter.Entities;
using payment_provider_integration.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace payment_provider_integration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        private readonly IDummyPaymentService _paymentService;
        private readonly ILogger _logger;


        public PaymentsController(IDummyPaymentService paymentService, ILogger logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        // POST: api/payments/create-payment
        [AllowAnonymous]
        [HttpPost("create-payment")]
        public async Task<IActionResult> CallCreatePaymentService([FromBody] PaymentDetails payment_details)
        {
            var response = await _paymentService.CreatePayment(payment_details);

            if (response.IsSuccessStatusCode)
            {
                _logger.Information("DONE: Payment Created Successfully. The Status Code is " + response.StatusCode);

                var data = JsonConvert.SerializeObject(response);

                return Ok(data);
            }
            return BadRequest();
        }

        // POST: api/payments/confirm-payment
        [AllowAnonymous]
        [HttpPost("confirm-payment")]
        public async Task<IActionResult> CallConfirmPaymentService([FromBody] ConfirmDetails confirm_details)
        {
            var response = await _paymentService.ConfirmPayment(confirm_details);

            if (response.IsSuccessStatusCode)
            {
                _logger.Information("DONE: Payment Created Successfully. The Status Code is " + response.StatusCode);

                var json = JsonConvert.SerializeObject(response);

                return Ok(json);
            }
            return BadRequest();
        }

        // GET: api/payments/get-payment-status/{transaction_id}
        [AllowAnonymous]
        [HttpGet("get-payment-status/{transaction_id}")]
        public async Task<IActionResult> CallGetPaymentStatusService(string transaction_id)
        {
            var response = await _paymentService.GetPaymentStatus(transaction_id);

            if (response.IsSuccessStatusCode)
            {
                _logger.Information("DONE: Payment Created Successfully. The Status Code is " + response.StatusCode);

                var json = JsonConvert.SerializeObject(response);

                return Ok(json);
            }
            return BadRequest();
        }

    }
}
