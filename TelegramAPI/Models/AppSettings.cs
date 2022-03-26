namespace TelegramAPI.Models
{
    internal class AppSettings
    {
        private static string url;
        private static string name;
        private static string key;

        public static string Url 
        {
            get { return url; }
        }

        public static string Name
        {
            get { return name; }
        }

        public static string Key
        {
            get { return key; }
        }

        internal AppSettings(String nameBot, String keyBot, String urlBot)
        {
            name = nameBot;
            key = keyBot;
            url = urlBot;
        }
    }
}
