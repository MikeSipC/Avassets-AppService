using Newtonsoft.Json;
using System;

namespace ExampleService.Customer.Api.Models.Requests
{
    public class GetCustomerResponseDto
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }
        [JsonProperty("fullName", Required = Required.Always)]
        public string FullName { get; set; }
    }
}