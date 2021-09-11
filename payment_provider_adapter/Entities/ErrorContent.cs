using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.Entities
{
    public class ErrorContent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
