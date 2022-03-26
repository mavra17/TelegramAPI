using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using TelegramAPI.Models;

namespace TelegramAPI.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "get test";
        }

        [HttpPost]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if ( update == null) return Ok();

            var commands = Bot.Commands;
            var message = update.Message;

            var botClient = await Bot.GetBotClientAsync();

            foreach (var command in commands)
            {
                if (command.Contains(message))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}