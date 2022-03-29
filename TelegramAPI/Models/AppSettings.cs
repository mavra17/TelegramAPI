namespace TelegramAPI.Models
{
    internal static class AppSettings
    {
        //bot conf
        private static string url;
        private static string name;
        private static string key;
        //pg conf
        private static string pgHost;
        private static string pgPort;
        private static string pgDatabase;
        private static string pgUserName;
        private static string pgPassword;

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

        public static string PgHost
        {
            get { return pgHost; }
        }

        public static string PgPort
        {
            get { return pgPort; }
        }

        public static string PgDatabase
        {
            get { return pgDatabase; }
        }

        public static string PgUserName
        {
            get { return pgUserName; }
        }

        public static string PgPassword
        {
            get { return pgPassword; }
        }

        internal static void SetAppSettings(String nameBot, String keyBot, String urlBot, String PgHost, String PgPort, String PgDB, String PgUsName, String PgPass)
        {
            name = nameBot;
            key = keyBot;
            url = urlBot;
            pgHost = PgHost;
            pgPort = PgPort;
            pgDatabase = PgDB;
            pgUserName = PgUsName;
            pgPassword = PgPass;
        }
    }
}
