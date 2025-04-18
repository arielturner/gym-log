using GymLog.API.Utilities;
using GymLog.BLL;
using GymLog.BLL.Services;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    // Use custom route convention for controllers
    options.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseTransformer()));
});


// Register GymLogContext
builder.Services.AddDbContext<GymLogContext>(options =>
{
    // Configure your database connection here
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register BodyPartsService and IBodyPartsService
builder.Services.AddScoped<IBodyPartsService, BodyPartsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
