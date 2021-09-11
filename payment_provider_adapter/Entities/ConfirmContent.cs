using Newtonsoft.Json;

namespace payment_provider_adapter.CustomResponses
{
    public class ConfirmContent
    {
        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("orderId")]
        public string OrderId { get; set; }

        [JsonProperty("lastFourDigits")]
        public string LastFourDigits { get; set; }
    }
}
