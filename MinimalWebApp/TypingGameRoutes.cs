namespace MinimalWebApp;

public static class TypingGameRoutes
{
    private const string ContentType = "text/html; charset=utf-8";
    private static readonly Dictionary<Guid, Stack<string>> games = [];

    public static void MapTypingGameRoutes(this WebApplication app)
    {
        app.MapGet("/{name}", (string name) =>
        {
            var html = File.ReadAllText(@"Html/game.html");
            return Results.Content(html, ContentType);
        });

        app.MapPost("/game", () =>
        {
            var id = Guid.NewGuid();

            var choices = Directory.EnumerateFiles("Text").Select(x => Path.GetFileNameWithoutExtension(x));

            var text = File
                .ReadAllText("Text/" + Path.ChangeExtension(choices.First(), ".txt"))
                .Replace("\"", "")
                .Replace("\n", "\r")
                .Replace("\r", "{{space}}")
                .Replace("{{space}}", " ");

            var words = text.Split(" ")
                .Where(x => !string.IsNullOrEmpty(x))
                .OrderBy(_ => Guid.NewGuid())
                .ToArray();

            var wordStack = new Stack<string>(words);

            games.Add(id, wordStack);

            var html = @$"
            <div id=""game-info"">
                <div>{wordStack.Peek()}</div>
                <form hx-post=""game/{id}/continue"" hx-target=""#game-info"" hx-swap=""outerHTML"">
                    <input id=""word"" autofocus type=""text"" name=""word""/>
                </form>
            </div>";

            return Results.Content(html, ContentType);
        });

        app.MapGet("/game/{id}", (Guid id) =>
        {
            var word = games[id].Peek();
            var html = $"<div>{word}</div>";

            return Results.Content(html, ContentType);
        });

        app.MapPost("/game/{id}/continue", (Guid id, HttpContext ctx) =>
        {
            var word = ctx.Request.Form["word"];

            var currentWord = games[id].Peek();
            if (currentWord != word)
            {
                return Results.Content(@$"
                <div id=""game-info"">
                    <div>{currentWord}</div>
                    <form hx-post=""game/{id}/continue"" hx-target=""#game-info"" hx-swap=""outerHTML"">
                        <input id=""word"" class=""horizontal-shaking"" type=""text"" name=""word"" value=""{word}""/>
                    </form>
                </div>",
                ContentType);
            }

            games[id].Pop();
            var nextWord = games[id].Peek();

            var html = @$"
            <div id=""game-info"">
                <div>{nextWord}</div>
                <form hx-post=""game/{id}/continue"" hx-target=""#game-info"" hx-swap=""outerHTML"">
                    <input id=""word"" autofocus type=""text"" name=""word""/>
                </form>
            </div>";

            return Results.Content(html, ContentType);
        });
    }
}
