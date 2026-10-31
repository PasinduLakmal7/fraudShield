var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "Healthy", service = "Transaction.API" }));

app.Run();
