using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SmsMessagesMicroService.Domain.Commands;

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
            return Ok(await CommandAsync(command));
        }

        [HttpGet("getallmessages")]
        public async Task<IActionResult> GetAllMessages()
        {
            return Ok(await QueryAsync(new GetAllMessagesCommand()));
        }

        [HttpGet("getmessagesbyid")]
        public async Task<IActionResult> GetMessagesById(int messageId)
        {
            return Single(await QueryAsync(new GetMessagesByIdCommand(messageId)));
        }
    }
}