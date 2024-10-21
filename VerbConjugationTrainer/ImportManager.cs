namespace VerbConjugationTrainer;

using HtmlAgilityPack;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VerbConjugationTrainer.Models;

public static class ImportManager
{
    private static readonly List<string> ActiveTimeForms =
    [
        "Indicative_Present",
        "Indicative_Past",
        "Indicative_Preterite",
        "Conditional_Present",
        "Indicative_Future",
        "Subjunctive_Present",
        "Subjunctive_Perfect"
    ];

    public static async Task<Verb> ParseVerbAsync(string verb)
    {
        await Task.Delay(1);

        var document = new HtmlDocument();
        document.Load($"Source/Html/{verb}.html");

        var node = document.DocumentNode.SelectSingleNode("//div[@class='verbtable']");

        var conjugations = ParseTables(node, "Indicative")
            .Concat(ParseTables(node, "Subjunctive"))
            .Concat(ParseTables(node, "Conditional"))
            .Where(x => ActiveTimeForms.Contains(x.TimeForm))
            .OrderBy(x => ActiveTimeForms.IndexOf(x.TimeForm))
            .ToList();

        return new Verb(new(string.Empty, verb, string.Empty), conjugations);
    }

    private static IEnumerable<Conjugations> ParseTables(HtmlNode node, string form)
    {
        return node.SelectSingleNode($".//h3[text()='{form}']/following-sibling::div")
            .SelectNodes(".//table")
            .Select(x => ParseTable(x, form));
    }

    private static Conjugations ParseTable(HtmlNode table, string formPrefix)
    {
        var rows = table.SelectNodes(".//tr");

        var translations = new List<Translation>();

        var timeForm = table.SelectSingleNode("preceding-sibling::h4[1]").InnerText;

        foreach (var row in rows)
        {
            var secondColumn = row.SelectSingleNode(".//td[2]");
            if (secondColumn != null)
            {
                translations.Add(new Translation(string.Empty, secondColumn.InnerText, string.Empty));
            }
        }

        return new Conjugations(
            $"{formPrefix}_{timeForm}",
            translations[0],
            translations[1],
            translations[2],
            translations[3],
            translations[5]);
    }
}
