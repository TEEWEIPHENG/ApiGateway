using Ocelot.DependencyInjection;
using Ocelot.Middleware;


var builder = WebApplication.CreateBuilder(args);

// Add Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.WithOrigins("http://cybertip.com")
              .AllowAnyMethod()
              .AllowAnyHeader();
        });
});

var app = builder.Build();

// Use Ocelot middleware
await app.UseOcelot();

app.Run();
