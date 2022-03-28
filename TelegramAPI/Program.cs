using TelegramAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("botconfig.json",optional:false,reloadOnChange:false);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

AppSettings appSettings = new AppSettings(
    app.Configuration["botName"],
    app.Configuration["botKey"],
    app.Configuration["botUrl"]
    );

Bot.GetBotClientAsync().Wait();

app.Run();