using TelegramAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();

builder.Configuration.AddJsonFile("botconfig.json",optional:false,reloadOnChange:false);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

AppSettings.SetAppSettings(
    app.Configuration["botName"],
    app.Configuration["botKey"],
    app.Configuration["botUrl"],
    app.Configuration["pgHost"],
    app.Configuration["pgPort"],
    app.Configuration["pgDatabase"],
    app.Configuration["pgUserName"],
    app.Configuration["pgPassword"]
    );

Bot.GetBotClientAsync().Wait();

app.Run();