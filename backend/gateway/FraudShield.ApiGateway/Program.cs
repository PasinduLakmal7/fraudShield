var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();

app.MapGet("/health", () => Results.Ok(new { status = "Healthy", service = "FraudShield.ApiGateway" }));

app.Run();

