using TelegramAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("botconfig.json",optional:false,reloadOnChange:false);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

AppSettings.SetAppSettings(app.Configuration);

SetWebHookTelegram();

Bot.GetBotClientAsync().Wait();

app.Run();


async void SetWebHookTelegram()
{
    using (var client = new HttpClient())
    {
        string adr = String.Format("https://api.telegram.org/bot{0}/setwebhook?url={1}",AppSettings.Key,AppSettings.Url);
        // when exec async we cennot registr bot's webhook
        var result = client.GetStringAsync(adr).Result;
        Console.WriteLine("Webhook set result: " + result);
    }
}