using Telegram.Bot;
using Telegram.Bot.Types;


namespace TelegramAPI.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => @"/start";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, "Привет, я чатбот для создания заметок", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
