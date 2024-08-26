using Spectre.Console;
using System.Text.Json;
using VerbConjugationTrainer;
using VerbConjugationTrainer.Models;

//var imported = await ImportManager.ParseVerbAsync("querer");
//var json = JsonSerializer.Serialize(imported);

Launch();

var playing = true;
while (playing)
{
    Play();
}

//TODO: dont keep i,you, he, they info in the string itself. find better data structure so that the english sentence can be decided on the fly
// e.g. that she is, if he is, that he is, etc.
//TODO: maybe in that structure also keep the spanish word and then show it optionally (yo) soy

Exit();

static void Launch()
{
    Console.OutputEncoding = System.Text.Encoding.UTF8;

    var text = new FigletText("Conjugator")
        .LeftJustified()
        .Color(Color.Aqua);

    AnsiConsole.Write(text);
    AnsiConsole.WriteLine();
}

void Play()
{
    var verb = PromptVerb();
    var timeForms = PromptTimeForms(verb);

    AnsiConsole.WriteLine("Please type the spanish conjugated verb.");

    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine($"Current Verb: [bold yellow]{verb.RegularForm.Spanish} - {verb.RegularForm.English}[/]");

    //TODO: filter out subjunctive perfect or others
    foreach (var conjugation in verb.Conjugations.Where(x => timeForms.Contains(x.TimeForm)))
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine($"Current Form: [bold yellow]{conjugation.TimeForm}[/]");

        var enMaxLength = conjugation.GetMaxEnglishLength();

        AskQuestion(conjugation.FirstPersonSingular, enMaxLength);
        AskQuestion(conjugation.SecondPersonSingular, enMaxLength);
        AskQuestion(conjugation.ThirdPersonSingular, enMaxLength);
        AskQuestion(conjugation.FirstPersonPlural, enMaxLength);
        AskQuestion(conjugation.ThirdPersonPlural, enMaxLength);
    }

    AnsiConsole.WriteLine();

    playing = AnsiConsole.Prompt(new ConfirmationPrompt("Continue?"));
    AnsiConsoleOverwriteLine(new string(' ', 100));

    AnsiConsole.WriteLine();
}

static Verb PromptVerb()
{
    var choices = Directory.EnumerateFiles("Source/Json")
        .Select(x => Path.GetFileNameWithoutExtension(x));

    var fileName = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Which [blue]verb[/] to you want to practice?")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
            .AddChoices(choices));

    return JsonSerializer.Deserialize<Verb>(File.ReadAllText($"Source/Json/{fileName}.json"))!;
}

static IEnumerable<string> PromptTimeForms(Verb verb)
{
    var choices = verb.Conjugations.Select(x => x.TimeForm).Distinct();

    return AnsiConsole.Prompt(
        new MultiSelectionPrompt<string>()
            .Title("Select conjugation forms")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
            .InstructionsText(
                "[grey](Press [blue]<space>[/] to select, " +
                "[green]<enter>[/] to accept)[/]")
            .AddChoices(choices));
}

static void AskQuestion(Translation translation, int maxEnLength)
{
    var padding = new string(' ', maxEnLength - translation.English.Length);
    var question = $"{translation.English} {padding}:";

    var answer = AnsiConsole.Ask<string>($"🕳️ {question}");
    var solutions = translation.Spanish.Split(",");

    if (solutions.Contains(answer))
    {
        AnsiConsoleOverwriteLine($"✅ {question} {answer}");
        return;
    }

    AnsiConsoleOverwriteLine($"❌ {question} {answer} => {translation.Spanish}");
    AskQuestion(translation, maxEnLength);
}

static void AnsiConsoleOverwriteLine(string input)
{
    AnsiConsole.Cursor.Move(CursorDirection.Up, 1);
    AnsiConsole.WriteLine(input);
}

static void Exit()
{
    AnsiConsole.WriteLine("Thank you for playing :)");
    AnsiConsole.Write("press any key to exit..");
    Console.ReadKey();
}