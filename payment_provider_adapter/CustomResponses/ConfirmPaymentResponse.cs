using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.CustomResponses
{
    public class ConfirmPaymentResponse : ICustomResponse
    {
        [JsonProperty("result")]
        public ConfirmContent ConfirmContent { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("isSuccessStatusCode")]
        public bool IsSuccessStatusCode { get; set; }
    }
}
