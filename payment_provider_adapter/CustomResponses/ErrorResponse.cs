using Newtonsoft.Json;
using payment_provider_adapter.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.CustomResponses
{
    public class ErrorResponse : ICustomResponse
    {
        [JsonProperty("errors")]
        public ErrorContent ErrorContent { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("isSuccessStatusCode")]
        public bool IsSuccessStatusCode { get; set; }
    }
}
