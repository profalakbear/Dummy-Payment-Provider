using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.Entities
{
    public class ConfirmDetails
    {
        public ConfirmDetails()
        {

        }

        public ConfirmDetails(string _TransactionId, string _PaRes)
        {
            TransactionId = _TransactionId;
            PaRes = _PaRes;
        }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("paRes")]
        public string PaRes { get; set; }
    }
}
