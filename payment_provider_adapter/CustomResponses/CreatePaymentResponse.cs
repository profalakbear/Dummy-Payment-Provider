using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.CustomResponses
{
    public class CreatePaymentResponse : ICustomResponse
    {
        [JsonProperty("result")]
        public CreateContent CreateContent { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("isSuccessStatusCode")]
        public bool IsSuccessStatusCode { get; set; }
    }
}
