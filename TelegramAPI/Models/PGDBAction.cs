using Npgsql;

namespace TelegramAPI.Models
{
    internal class PGDBCommand
    {
        private string conStr;

        internal PGDBCommand()
        {
            conStr = String.Format("Host={0};Port={1};Username={2};Password={3};Database={4}",
                AppSettings.PgHost, AppSettings.PgPort, AppSettings.PgUserName, AppSettings.PgPassword, AppSettings.PgDatabase);
        }
        internal bool ChekUpdate(int msgID)
        {
            bool queryRez = true;
            using (var con = new NpgsqlConnection(conStr))
            {
                con.Open();
                using (var cmd = new NpgsqlCommand(string.Format("SELECT messageId FROM messageFromTelegram WHERE messageId = {0} LIMIT 1", msgID), con))
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            queryRez = false;
                        }
                    }
                }
                if (queryRez)
                {
                    using (var cmd = new NpgsqlCommand(string.Format("INSERT INTO messageFromTelegram (messageId) VALUES ({0})", msgID), con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return queryRez;
        }
    }
}
