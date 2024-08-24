using Spectre.Console;
using VerbConjugationTrainer;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var rng = new Random();

//TODO: correct mistake immediately -> prompt input again and re-set line
//TODO: dont keep i,you, he, they info in the string itself. find better data structure so that the english sentence can be decided on the fly
// e.g. that she is, if he is, that he is, etc.
//TODO: maybe in that structure also keep the spanish word and then show it optionally (yo) soy

AnsiConsole.WriteLine("Please type the spanish conjugated verb.");

foreach (var verb in ConjugatedVerbs.verbs.OrderBy(_ => rng.Next()))
{
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine($"Current Verb: [bold yellow]{verb.Key}[/]");

    foreach (var (en, esp) in verb.Value)
    {
        var question = $"{en}: ";
        var answer = AnsiConsole.Ask<string>(question);

        var output = string.Empty;
        if (answer == esp)
        {
            output = $"{question}{answer} ✅";
        }
        else
        {
            output = $"{question}{answer} ❌ => {esp}";
        }

        AnsiConsoleOverwriteLine(output);
    }
}


AnsiConsole.Write("Finished everything :) press any key to exit..");
Console.ReadKey();

static void AnsiConsoleOverwriteLine(string input)
{
    AnsiConsole.Cursor.Move(CursorDirection.Up, 1);
    AnsiConsole.WriteLine(input);
}