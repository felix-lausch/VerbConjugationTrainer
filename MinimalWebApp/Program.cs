using MinimalWebApp;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapRoutes();
app.MapTypingGameRoutes();

app.Run();
