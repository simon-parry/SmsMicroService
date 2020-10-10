using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsMessagesMicroService.Domain.Commands;
using System;
using System.Threading.Tasks;

namespace SmsMessagesMicroService.Api.Controllers
{
    [EnableCors("CorsApiPolicy"), Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ApiBaseController
    {
        public MessagesController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost("sendmessage")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageCommand command)
        {
            try
            {
                return Ok(await CommandAsync(command));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error sending message:{e.Message}"
                });
            }
        }

        [HttpGet("getallmessages")]
        public async Task<IActionResult> GetAllMessages()
        {
            try
            {
                return Ok(await QueryAsync(new GetAllMessagesCommand()));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error getting all messages:{e.Message}"
                });
            }
        }

        [HttpGet("getmessagesbyid")]
        public async Task<IActionResult> GetMessagesById(int messageId)
        {
            try
            {
                return Single(await QueryAsync(new GetMessagesByIdCommand(messageId)));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Error getting messages by id ({messageId}):{e.Message}"
                });
            }
        }
    }
}