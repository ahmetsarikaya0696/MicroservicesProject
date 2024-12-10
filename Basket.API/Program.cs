using Basket.API;
using Basket.API.Features;
using Basket.API.Features.Basket;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCommonServicesExtension(typeof(BasketApiAssembly));
builder.Services.AddVersioningExtension();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

builder.Services.AddScoped<IBasketService, BasketService>();

var app = builder.Build();

var apiVersionSet = app.GetVersionSetExtension();
app.AddBasketEndpointsExtension(apiVersionSet);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();