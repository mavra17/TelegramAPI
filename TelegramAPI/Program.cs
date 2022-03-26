using TelegramAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("botconfig.json",optional:false,reloadOnChange:false);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

AppSettings appSettings = new AppSettings(
    app.Configuration["botName"],
    app.Configuration["botKey"],
    app.Configuration["urlBot"]
    );
Bot.GetBotClientAsync().Wait();

app.Run();