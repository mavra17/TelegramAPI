using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramAPI.Models;

namespace TelegramAPI.Controllers
{
    [ApiController]
    [Route("api/message")]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<OkResult> Post([FromBody] Update update)
        {
            if ( update == null) return Ok();

            var message = update.Message;
            var pgbbAction = new PGDBCommand();

            if (pgbbAction.ChekUpdate(message.MessageId))
            {
                var commands = Bot.Commands;
                var botClient = await Bot.GetBotClientAsync();

                bool comNotFound = true;

                foreach (var command in commands)
                {
                    if (command.Contains(message))
                    {
                        await command.Execute(message, botClient);
                        comNotFound = false;
                        break;
                    }
                }
                if (comNotFound)
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Я не понял что ты от меня хочешь", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
            }
            return Ok();
        }
    }
}