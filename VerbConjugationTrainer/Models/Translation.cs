namespace VerbConjugationTrainer.Models;

public record Translation(string English, string Spanish, string PronounSpanish);

public enum TimeForm
{
    Indicative_Present,
    Indicative_Preterite,
    Indicative_Imperfect,
    Indicative_Conditional,
    Indicative_Future,
    Subjunctive_Present,
    Subjunctive_Imperfect,
}

public class Conjugations(
    string timeForm,
    Translation? firstPersonSingular,
    Translation? secondPersonSingular,
    Translation? thirdPersonSingular,
    Translation? firstPersonPlural,
    Translation? thirdPersonPlural)
{
    public string TimeForm => timeForm;
    public Translation? FirstPersonSingular => firstPersonSingular is null ? null : firstPersonSingular with { PronounSpanish = "yo" };
    public Translation? SecondPersonSingular => secondPersonSingular is null ? null : secondPersonSingular with { PronounSpanish = "tu" };
    public Translation? ThirdPersonSingular => thirdPersonSingular is null ? null : thirdPersonSingular with { PronounSpanish = "el/ella" };
    public Translation? FirstPersonPlural => firstPersonPlural is null ? null : firstPersonPlural with { PronounSpanish = "nosotros" };
    public Translation? ThirdPersonPlural => thirdPersonPlural is null ? null : thirdPersonPlural with { PronounSpanish = "ustedes" };

    public int GetMaxEnglishLength()
    {
        string?[] eng =
        [
            firstPersonSingular?.English,
            secondPersonSingular?.English,
            thirdPersonSingular?.English,
            firstPersonPlural?.English,
            thirdPersonPlural?.English,
        ];

        return eng.MaxBy(x => x?.Length)?.Length ?? 0;
    }

    public int GetMaxSpanishLength()
    {
        string?[] esp =
        [
            firstPersonSingular?.Spanish,
            secondPersonSingular?.Spanish,
            thirdPersonSingular?.Spanish,
            firstPersonPlural?.Spanish,
            thirdPersonPlural?.Spanish,
        ];

        return esp.MaxBy(x => x?.Length)?.Length ?? 0;
    }
};

public record Verb(Translation RegularForm, List<Conjugations> Conjugations);
