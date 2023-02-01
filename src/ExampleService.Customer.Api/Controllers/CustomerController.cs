using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ExampleService.Customer.Api.Models.Requests;
using Microsoft.Extensions.Logging;
using ExampleService.Core.Queries.Customer;

namespace ExampleService.Customer.Api.Controllers
{
    
    [Route("/api/{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public CustomerController(IMediator mediator, IMapper mapper, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet()]
        public async Task<GetCustomerResponseDto> GetCustomer(int id)
        {
            _logger.LogInformation("GetCustomer: {id}", id);

            var rv = await _mediator.Send(new GetCustomerDetailsQuery { Id = id }).ConfigureAwait(false);
            var dto = _mapper.Map<GetCustomerResponseDto>(rv);
            return dto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<string> CreateCustomer([FromBody] CreateCustomerRequestDto request)
        {
            //var serializedObject = JsonConvert.SerializeObject(request);
            //_logger.LogInformation(serializedObject);
            //var rv = await _mediator.Send(new CreateAccountHolderCommand
            //{
            //    LegalEntity = request.LegalEntity,
            //    Venue = new CreateAccountHolderCommand.VenueData
            //    {
            //        Id = request.Venue.Id,
            //        CountryCode = request.CountryCode,
            //        Email = request.Venue.Email,
            //        Title = request.Venue.Title
            //    },
            //    User = new CreateAccountHolderCommand.UserData
            //    {
            //        FirstName = request.User.FirstName,
            //        LastName = request.User.LastName,
            //        Email = request.User.Email,
            //    }
            //}).ConfigureAwait(false);

            //var dto = _mapper.Map<CreateAccountHolderResponseDto>(rv);
            //return dto;

            return "";
        }
    }
}