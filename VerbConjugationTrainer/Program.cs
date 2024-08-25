using Spectre.Console;
using System.Text.Json;
using VerbConjugationTrainer;
using VerbConjugationTrainer.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;

//var res = await ImportManager.ParseVerbAsync("hacer");

var res = JsonSerializer.Deserialize<Verb>(File.ReadAllText("source/hacer.json"));

AnsiConsole.WriteLine("Please type the spanish conjugated verb.");

AnsiConsole.WriteLine();
AnsiConsole.MarkupLine($"Current Verb: [bold yellow]{res.RegularForm.Spanish} - {res.RegularForm.English}[/]");

foreach (var conjugation in res.Conjugations)
{
    AskQuestion(conjugation.FirstPersonSingular);
    AskQuestion(conjugation.SecondPersonSingular);
    AskQuestion(conjugation.ThirdPersonSingular);
    AskQuestion(conjugation.FirstPersonPlural);
    AskQuestion(conjugation.ThirdPersonPlural);
}

//var rng = new Random();

//TODO: correct mistake immediately -> prompt input again and re-set line
//TODO: dont keep i,you, he, they info in the string itself. find better data structure so that the english sentence can be decided on the fly
// e.g. that she is, if he is, that he is, etc.
//TODO: maybe in that structure also keep the spanish word and then show it optionally (yo) soy

//var verb = AnsiConsole.Prompt(
//    new SelectionPrompt<string>()
//        .Title("Which verb to you want to [green]practice[/]?")
//        .PageSize(10)
//        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
//        .AddChoices(ConjugatedVerbs.verbs.Keys.ToArray()));

//foreach (var verb in ConjugatedVerbs.verbs.OrderBy(_ => rng.Next()))
//{
    //AnsiConsole.WriteLine();
    //AnsiConsole.MarkupLine($"Current Verb: [bold yellow]{verb}[/]");

    //foreach (var (en, esp) in ConjugatedVerbs.verbs[verb])
    //{
    //    var question = $"{en}: ";
    //    var answer = AnsiConsole.Ask<string>(question);

    //    var output = string.Empty;
    //    if (answer == esp)
    //    {
    //        output = $"{question}{answer} ✅";
    //    }
    //    else
    //    {
    //        output = $"{question}{answer} ❌ => {esp}";
    //    }

    //    AnsiConsoleOverwriteLine(output);
    //}
//}


AnsiConsole.Write("Finished everything :) press any key to exit..");
Console.ReadKey();

static void AskQuestion(Translation translation)
{
    var question = $"{translation.English}: ";
    var answer = AnsiConsole.Ask<string>(question);

    var output = string.Empty;
    if (answer == translation.Spanish)
    {
        output = $"{question}{answer} ✅";
    }
    else
    {
        output = $"{question}{answer} ❌ => {translation.Spanish}";
    }

    AnsiConsoleOverwriteLine(output);
}

static void AnsiConsoleOverwriteLine(string input)
{
    AnsiConsole.Cursor.Move(CursorDirection.Up, 1);
    AnsiConsole.WriteLine(input);
}