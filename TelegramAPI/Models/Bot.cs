using Telegram.Bot;
using TelegramAPI.Models.Commands;

namespace TelegramAPI.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandList;

        public static IReadOnlyList<Command> Commands => commandList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandList = new List<Command>();
            commandList.Add(new StartCommand());

            botClient = new TelegramBotClient(AppSettings.Key);

            await botClient.SetWebhookAsync(AppSettings.Url);
            return botClient;
        }
    }
}
