using GymLog.API.Services;
using GymLog.API.Utilities;
using GymLog.BLL;
using GymLog.BLL.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddSerilog();

    builder.Services.AddMemoryCache();
    builder.Services.AddHttpContextAccessor();

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

    // Register my services
    builder.Services.AddScoped<IBodyPartsService, BodyPartsService>();
    builder.Services.AddScoped<IExercisesService, ExercisesService>();
    builder.Services.AddTransient<ICurrentUserService, CurrentUserService>();
    builder.Services.AddSingleton<IOneRepMaxEstimator, OneRepMaxEstimator>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);

    // Add CORS policy to allow localhost:4200
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost4200", policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });

    var app = builder.Build();

    // Use CORS policy
    app.UseCors("AllowLocalhost4200");

    app.UseExceptionHandler(errorApp =>
    {
        errorApp.Run(async context =>
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is KeyNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new { message = exception.Message });
            }
            else if (exception is InvalidOperationException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new { message = exception.Message });
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new { message = "An unexpected error occurred." });
                Log.Error(exception, "An error occurred.");
            }
        });
    });

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
