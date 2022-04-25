var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => 
    p.AddPolicy("app", builder =>
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

app.UseCors("app");

app.MapGet("/message/admin", () => "Hello admin.");
app.MapGet("/message/portal", () => "Hello portal.");

app.Run();
