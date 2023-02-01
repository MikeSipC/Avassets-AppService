using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExampleService.Customer.Api.Controllers
{
    [Route("/api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AddressController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<AddressController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public AddressController(IMediator mediator,
            IMapper mapper,
            ILogger<AddressController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postalCode"></param>
        /// <returns></returns>
        [HttpGet("{postalCode}")]
        public async Task<string> GetAddressesByPostalCode(string postalCode)
        {
            //var paymentMethods = await _mediator.Send(new GetPaymentProvidersQuery
            //{
            //    VenueId = venueId,
            //    ShopperReference = shopperReference
            //}).ConfigureAwait(false);

            //var dto = _mapper.Map<GetPaymentMethodsResponseDto>(paymentMethods);
            //return dto;
            return "";
        }
    }
}