using System.Text;
using System.Xml.Linq;

namespace MinimalWebApp;

public static class Routes
{
    private static readonly Random random = new Random();

    public static void MapRoutes(this WebApplication app)
    {
        app.MapGet("/", () =>
        {
            var html = File.ReadAllText(@"Html/index.html");

            var choices = Directory.EnumerateFiles("Text").Select(x => Path.GetFileNameWithoutExtension(x));
            //var items = string.Join("\n", choices.Select(x => $"<li hx-get=\"/text/{x}\" hx-target=\"#item-list\" hx-swap=\"innerHTML\">{x}</li>"));
            var items = string.Join("\n", choices.Select(x => $"<li><a href=\"{x}\">{x}</a></li>"));

            html = html.Replace("{{items}}", items);

            return Results.Content(html, "text/html; charset=utf-8");
        });

        app.MapGet("/{name}", (string name) =>
        {
            var text = File.ReadAllText("Text/" + Path.ChangeExtension(name, ".txt"));
            text = text.Replace("\n", "<br/>").Replace("\r\n", "<br/>");

            var html = $@"
                <button hx></button>
<p>{text}</p>";

            return Results.Content(html, "text/html; charset=utf-8");
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
