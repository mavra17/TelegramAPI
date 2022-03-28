using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramAPI.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, TelegramBotClient client);

        public virtual bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            bool resRez = false;
            if (message.EntityValues != null)
                foreach (var mesToCom in message.EntityValues)
                {
                    if (mesToCom.Contains(this.Name))
                    {
                        resRez = true;
                        break;
                    }
                }

            return resRez;
        }
    }
}
