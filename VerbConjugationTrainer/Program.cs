using Spectre.Console;
using System.Text.Json;
using VerbConjugationTrainer;
using VerbConjugationTrainer.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//var imported = await ImportManager.ParseVerbAsync("querer");
//var json = JsonSerializer.Serialize(imported);

var fileName = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Which [blue]verb[/] to you want to practice?")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
        .AddChoices(Directory.EnumerateFiles("Source/Json").Select(x => Path.GetFileName(x))));

var verb = JsonSerializer.Deserialize<Verb>(File.ReadAllText($"Source/Json/{fileName}"))!;

AnsiConsole.WriteLine("Please type the spanish conjugated verb.");

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine($"Current Verb: [bold yellow]{verb.RegularForm.Spanish} - {verb.RegularForm.English}[/]");

foreach (var conjugation in verb.Conjugations)
{
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine($"Current Form: [bold yellow]{conjugation.TimeForm}[/]");

    AskQuestion(conjugation.FirstPersonSingular);
    AskQuestion(conjugation.SecondPersonSingular);
    AskQuestion(conjugation.ThirdPersonSingular);
    AskQuestion(conjugation.FirstPersonPlural);
    AskQuestion(conjugation.ThirdPersonPlural);
}

//var rng = new Random();
//.OrderBy(_ => rng.Next())

//TODO: dont keep i,you, he, they info in the string itself. find better data structure so that the english sentence can be decided on the fly
// e.g. that she is, if he is, that he is, etc.
//TODO: maybe in that structure also keep the spanish word and then show it optionally (yo) soy

AnsiConsole.Write("Good job :) press any key to exit..");
Console.ReadKey();

static void AskQuestion(Translation translation)
{
    var question = $"{translation.English}: ";

    var answer = AnsiConsole.Ask<string>(question);

    if (answer == translation.Spanish)
    {
        AnsiConsoleOverwriteLine($"{question}{answer} ✅");
        return;
    }
    
    AnsiConsoleOverwriteLine($"{question}{answer} ❌ => {translation.Spanish}");
    AskQuestion(translation);
}

static void AnsiConsoleOverwriteLine(string input)
{
    AnsiConsole.Cursor.Move(CursorDirection.Up, 1);
    AnsiConsole.WriteLine(input);
}