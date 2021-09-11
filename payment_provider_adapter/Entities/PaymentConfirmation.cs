using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.Entities
{
    public class PaymentConfirmation
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("paRes")]
        public string Pares { get; set; }
    }
}
