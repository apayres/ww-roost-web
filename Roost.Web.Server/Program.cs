using Roost.Web.Server.Messaging;
using Roost.Web.Server.Messaging.Configuration;
using Roost.Web.Server.Repositories;
using Roost.Web.Server.Repositories.Configuration;
using Roost.Web.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(1000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// APP OPTIONS
builder.Services.Configure<RepoOptions>(x =>
{
    x.CosmosConnectionString = builder.Configuration.GetConnectionString("CosmosConnectionString");
});

builder.Services.Configure<ServiceBusOptions>(x =>
{
    x.ServiceBusConnectionString = builder.Configuration.GetConnectionString("ServiceBusConnectionString");
});

// APP SERVICES
builder.Services.AddSingleton<IItemRepository, ItemRepository>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddSingleton<IServiceBusMessageSender, ServiceBusMessageSender>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
