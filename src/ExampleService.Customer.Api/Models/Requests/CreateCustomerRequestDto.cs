using Newtonsoft.Json;

namespace ExampleService.Customer.Api.Models.Requests
{
    public class CreateCustomerRequestDto
    {
        [JsonProperty("firstName", Required = Required.Always)]
        public string FirstName { get; set; }
        [JsonProperty("lastName", Required = Required.Always)]
        public string LastName { get; set; }
        [JsonProperty("age", Required = Required.Always)]
        public int Age { get; set; }
        [JsonProperty("postalCode", Required = Required.Always)]
        public string PostalCode { get; set; }
    }
}