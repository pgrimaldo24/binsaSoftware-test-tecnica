using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Application.CreateCustomerContact.Command;
using BinsaSoftware.ClientWebApp.Application.DeleteCustomer.Command;
using BinsaSoftware.ClientWebApp.Application.DeleteCustomerContact.Command;
using BinsaSoftware.ClientWebApp.Application.ListCustomer.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BinsaSoftware.ClientWebApp.Controllers.DistributedServices
{
    [Route("api/customerContact")]
    [ApiController]
    public class CustomerContactServicesController : ControllerBase 
    {
        private readonly IMediator _mediator;
        private readonly IListCustomerContactServices _listCustomerContactServices;
        public CustomerContactServicesController(
            IMediator mediator,
            IListCustomerContactServices listCustomerContactServices)
        {
            _mediator = mediator;
            _listCustomerContactServices = listCustomerContactServices; 
        }

        private IMediator Mediator => _mediator;
        private IListCustomerContactServices ListCustomerContactServices => _listCustomerContactServices;

        [HttpPost("create/customer/contact")]
        public async ValueTask<IActionResult> CreateCustomer([FromBody] CreateCustomerContactCommand request)
        {
            try
            {
                await Mediator.Send(new CreateCustomerContactCommand(request.clientId,
                                                                     request.names,
                                                                     request.phone,
                                                                     request.email));

                return Ok("The customer contact was registered successfully");
            }
            catch (Exception ex)
            {
                var message = string.Empty;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(message);
            }
        }

        [HttpGet("list/customer/contact/{id}")]
        public async ValueTask<IActionResult> ListCustomerContact(int id)
        {
            try
            {
                var result = await ListCustomerContactServices.GetCustomerContactAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var message = string.Empty;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(message);
            }
        }

        [HttpDelete("delete/contact/{id}")]
        public async ValueTask<IActionResult> DeleteContactById(int id)
        {
            try
            {
                var request = new DeleteCustomerContactCommand
                {
                    customerContactId = id
                };

                await Mediator.Send(request);

                return Ok("The contact was deleted successfully");
            }
            catch (Exception ex)
            {
                var message = string.Empty;
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message;
                return BadRequest(message);
            }
        }
    }
}
