using System;
using System.Collections.Generic;
using System.Text;

namespace payment_provider_adapter.CustomResponses
{
    public interface ICustomResponse
    {
        string StatusCode { get; set; }
        bool IsSuccessStatusCode { get; set; }
    }
}
