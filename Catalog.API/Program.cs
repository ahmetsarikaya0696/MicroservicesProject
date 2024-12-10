using Catalog.API;
using Catalog.API.Features.Categories;
using Catalog.API.Features.Courses;
using Catalog.API.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExtension();
builder.Services.AddDatabaseServiceExtension();

builder.Services.AddCommonServicesExtension(typeof(CatalogApiAssembly));

builder.Services.AddVersioningExtension();

var app = builder.Build();

app.AddSeedDataAsyncExtension().ContinueWith(x =>
{
    Console.WriteLine(x.IsFaulted ? x.Exception.Message : "Seed data has been saved successfully");
});

var apiVersionSet = app.GetVersionSetExtension();
app.AddCategoryEndpointsExtension(apiVersionSet);
app.AddCourseEndpointsExtension(apiVersionSet);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();