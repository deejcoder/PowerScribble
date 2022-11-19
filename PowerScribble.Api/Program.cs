using MediatR;
using PowerScribble.Api;
using PowerScribble.Api.Application.Interfaces;
using PowerScribble.Api.Persistance.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));

builder.Services.AddDbContext<PowerScribbleDbContext>();

builder.Services.AddScoped<IAppContext, PowerScribble.Api.AppContext>();
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(PowerScribble.Api.Infrastructure.Behaviors.MediatR.LoggingBehavior<,>));

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
app.UseMiddleware<PowerScribble.Api.Infrastructure.Behaviors.Api.LoggingBehavior>();

app.Run();
