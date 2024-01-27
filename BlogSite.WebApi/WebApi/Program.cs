using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Services.Concrats;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// nlog
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));



builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();
    

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// FilterActions
//builder.Services.ConfigureActionFilters();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
//builder.Services.ConfigureCors();
//builder.Services.ConfigureDataShaper();

// automapper
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// policy added
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();