using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using payment_provider_adapter.CustomResponses;
using payment_provider_adapter.Entities;
using payment_provider_adapter.Env;
using payment_provider_adapter.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace payment_provider_adapter.Implementations
{
    public class DummyPaymentAdapter : IDummyPaymentAdapter
    {
        private readonly IMapper _mapper;
        private readonly Uri baseAddress = new Uri(Variables.BaseAddress);

        public DummyPaymentAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ICustomResponse> ConfirmPayment([FromBody] ConfirmDetails entity)
        {
            ConfirmPaymentResponse responseToReturn = new ConfirmPaymentResponse();

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Mechant-Id", Variables.Mechant_Id);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Secret-Key", Variables.Secret_Key);

                using (var response = await httpClient.PostAsync("payment/confirm", content))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        ErrorResponse errorToReturn = new ErrorResponse();
                        var err = await response.Content.ReadAsStringAsync();
                        errorToReturn = JsonConvert.DeserializeObject<ErrorResponse>(err);
                        _mapper.Map(response, errorToReturn);

                        return errorToReturn;
                    }

                    var ctn = await response.Content.ReadAsStringAsync();
                    responseToReturn = JsonConvert.DeserializeObject<ConfirmPaymentResponse>(ctn);
                    _mapper.Map(response, responseToReturn);
                }
            }
            return responseToReturn;
        }

        public async Task<ICustomResponse> CreatePayment(PaymentDetails entity)
        {
            CreatePaymentResponse responseToReturn = new CreatePaymentResponse();

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Mechant-Id", Variables.Mechant_Id);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Secret-Key", Variables.Secret_Key);       

                using (var response = await httpClient.PostAsync("payment/create", content))
                {
                    if(!response.IsSuccessStatusCode)
                    {
                        ErrorResponse errorToReturn = new ErrorResponse();
                        var err = await response.Content.ReadAsStringAsync();
                        errorToReturn = JsonConvert.DeserializeObject<ErrorResponse>(err);
                        _mapper.Map(response, errorToReturn);

                        return errorToReturn;
                    }

                    var ctn = await response.Content.ReadAsStringAsync();
                    responseToReturn = JsonConvert.DeserializeObject<CreatePaymentResponse>(ctn);
                    _mapper.Map(response, responseToReturn);
                }
            }
            return responseToReturn;
        }

        public async Task<ICustomResponse> GetPaymentStatus(string transaction_id) 
        {
            StatusPaymentResponse responseToReturn = new StatusPaymentResponse();

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Mechant-Id", Variables.Mechant_Id);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Secret-Key", Variables.Secret_Key);

                using (var response = await httpClient.GetAsync($"payment/{transaction_id}/status"))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        ErrorResponse errorToReturn = new ErrorResponse();
                        var err = await response.Content.ReadAsStringAsync();
                        errorToReturn = JsonConvert.DeserializeObject<ErrorResponse>(err);
                        _mapper.Map(response, responseToReturn);

                        return errorToReturn;
                    }

                    var ctn = await response.Content.ReadAsStringAsync();
                    responseToReturn = JsonConvert.DeserializeObject<StatusPaymentResponse>(ctn);
                    _mapper.Map(response, responseToReturn);
                }
            }
            return responseToReturn;
        }
    }
}
