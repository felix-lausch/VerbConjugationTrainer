namespace MinimalWebApp;

public static class Routes
{
    private static readonly Random random = new Random();

    public static void MapRoutes(this WebApplication app)
    {
        app.MapGet("/", () =>
        {
            var html = File.ReadAllText(@"Html/index.html");
            return Results.Content(html, "text/html");
        });

        app.MapGet("/list", () =>
        {
            var html = @"<ul>{{innerList}}</ul>";

            var innerList = Enumerable
                .Range(1, random.Next(1, 7))
                .Select(i => $"<li>{i}</li>");

            html = html.Replace("{{innerList}}", string.Join("\n", innerList));

            return Results.Content(html, "text/html");
        });

        app.MapPost("/name", (HttpContext ctx) =>
        {
            var name = ctx.Request.Form["hello-input"];
            if (string.IsNullOrEmpty(name))
            {
                return Results.BadRequest();
                //return Results.Content("<h1>Hello World!</h1><div style=\"color:red\">Please input something</div>");
            }

            return Results.Content($"<h1>Hello {name}!</h1>", "text/html");
        });
    }
}
