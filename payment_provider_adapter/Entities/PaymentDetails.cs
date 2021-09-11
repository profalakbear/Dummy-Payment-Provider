using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.Entities
{
    public class PaymentDetails
    {
        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty("cardHolder")]
        public string CardHolder { get; set; }

        [JsonProperty("cardExpiryDate")]
        public string CardExpiryDate { get; set; }

        [JsonProperty("cvv")]
        public string Cvv { get; set; }
    }
}
