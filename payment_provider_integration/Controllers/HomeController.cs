using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using payment_provider_adapter.CustomResponses;
using payment_provider_adapter.Entities;
using payment_provider_integration.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace payment_provider_integration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDummyPaymentService _paymentService;


        public HomeController(IDummyPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult End()
        {
            ConfirmPaymentResponse cpr = new ConfirmPaymentResponse();

            var str = HttpContext.Session.GetString("PaymentResponse");

            ConfirmPaymentResponse obj = JsonConvert.DeserializeObject<ConfirmPaymentResponse>(str);

            return View(obj);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentDetails payment_details)
        {
            var response = await _paymentService.CreatePayment(payment_details);

            var data = JsonConvert.SerializeObject(response, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            HttpContext.Session.SetString("PaymentResponse", data);

            return Ok(data);
        }



        [HttpGet]
        public async Task<IActionResult> OkResult()
        {
            var str =HttpContext.Session.GetString("PaymentResponse");

            var obj = JsonConvert.DeserializeObject<CreatePaymentResponse>(str);

            string paRes = this.Request.Query["paRes"];

            string transactionId = obj.CreateContent.TransactionId;

            ConfirmDetails details = new ConfirmDetails(transactionId, paRes);

            var response = await _paymentService.ConfirmPayment(details);

            var data = JsonConvert.SerializeObject(response, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            HttpContext.Session.SetString("PaymentResponse", data);

            return RedirectToAction("End");
        }

    }
}
