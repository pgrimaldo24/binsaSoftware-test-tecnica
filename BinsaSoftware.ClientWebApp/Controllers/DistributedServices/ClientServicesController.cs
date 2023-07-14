using Azure.Core;
using BinsaSoftware.ClientWebApp.Application.Common.Interfaces;
using BinsaSoftware.ClientWebApp.Application.CreateCustomer.Command;
using BinsaSoftware.ClientWebApp.Application.DeleteCustomer.Command;
using BinsaSoftware.ClientWebApp.Application.UpdateCustomer.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BinsaSoftware.ClientWebApp.Controllers.DistributedServices
{
    [Route("api/client")]
    [ApiController]
    public class ClientServicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IListCustomerServices _listCustomerServices;
        private readonly IDetailCustomerServices _detailCustomerServices;

        public ClientServicesController(
            IMediator mediator, 
            IListCustomerServices listCustomerServices,
            IDetailCustomerServices detailCustomerServices)
        {
            _mediator = mediator;   
            _listCustomerServices = listCustomerServices;
            _detailCustomerServices = detailCustomerServices;
        }

        private IMediator Mediator => _mediator;
        private IListCustomerServices ListCustomerServices => _listCustomerServices;
        private IDetailCustomerServices DetailCustomerServices => _detailCustomerServices;


        [HttpPost("create/customer")]
        public async ValueTask<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
        {
            try
            {
                await Mediator.Send(new CreateCustomerCommand(request.names, 
                                                              request.homeAddress, 
                                                              request.postalCode, 
                                                              request.population));                
                return Ok("The customer registered successfully");
            }
            catch(Exception ex)
            {
                var message = string.Empty; 
                if (ex.InnerException != null)
                    message = ex.InnerException.Message;
                else
                    message = ex.Message; 
                return BadRequest(message);
            } 
        }

        [HttpGet("list/customer")]
        public async ValueTask<IActionResult> ListCustomer()
        {
            try
            {
                var result = await ListCustomerServices.GetListCustomerAsync();
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

        [HttpGet("detail/customer/{id}")]
        public async ValueTask<IActionResult> DetailCustomer(int id)
        {
            try
            {
                var result = await DetailCustomerServices.GetDetailCustomerByIdAsync(id);
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

        [HttpGet("drop/list/customer")]
        public async ValueTask<IActionResult> DropListCustomer()
        {
            try
            {
                var result = await ListCustomerServices.GetCustomerAsync();
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

        [HttpPut("update/customer")]
        public async ValueTask<IActionResult> UpdateCustomerById([FromBody] UpdateRequestDto updateCustomerCommand)
        {
            try
            {  
                await Mediator.Send(new UpdateCustomerCommand(updateCustomerCommand.ClientId,
                                                             updateCustomerCommand.Nombre,
                                                             updateCustomerCommand.Domicilio,
                                                             updateCustomerCommand.CodigoPostal,
                                                             updateCustomerCommand.Poblacion));

                return Ok("The client was successfully updated");
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

        [HttpDelete("delete/customer/{id}")]
        public async ValueTask<IActionResult> DeleteCustomerById(int id)
        {
            try
            {
                var request = new DeleteCustomerCommand
                {
                    clientId = id
                };

                await Mediator.Send(request);

                return Ok("The client was successfully removed");
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
