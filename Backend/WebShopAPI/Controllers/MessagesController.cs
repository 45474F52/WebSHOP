using Microsoft.AspNetCore.Mvc;
using WebShopAPI.Models.DTO;
using WebShopAPI.Models.Messangers;

namespace WebShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class MessagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MessagesController(IConfiguration configuration) => _configuration = configuration;

        [HttpPost]
        public async Task<ActionResult> RequestToOrder([FromBody] RequestToOrderDTO data)
        {
            (bool hasErrors, object? errors) result = default;
            SMTPMessanger messanger = new SMTPMessanger(_configuration);
            messanger.Callback += args => result = args;
            await messanger.SendAsync(data.AsMessage(), CancellationToken.None);
            if (result.hasErrors)
                return BadRequest(result.errors);
            return Ok();
        }
    }
}
