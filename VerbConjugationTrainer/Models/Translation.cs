namespace VerbConjugationTrainer.Models;

public record Translation(string English, string Spanish);

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

public record Conjugations(
    string TimeForm,
    Translation FirstPersonSingular,
    Translation SecondPersonSingular,
    Translation ThirdPersonSingular,
    Translation FirstPersonPlural,
    Translation ThirdPersonPlural)
{
    public int GetMaxEnglishLength()
    {
        string[] eng =
        [
            FirstPersonSingular.English,
            SecondPersonSingular.English,
            ThirdPersonSingular.English,
            FirstPersonPlural.English,
            ThirdPersonPlural.English,
        ];

        return eng.MaxBy(x => x.Length)?.Length ?? 0;
    }

    public int GetMaxSpanishLength()
    {
        string[] esp =
        [
            FirstPersonSingular.Spanish,
            SecondPersonSingular.Spanish,
            ThirdPersonSingular.Spanish,
            FirstPersonPlural.Spanish,
            ThirdPersonPlural.Spanish,
        ];

        return esp.MaxBy(x => x.Length)?.Length ?? 0;
    }
};

public record Verb(Translation RegularForm, List<Conjugations> Conjugations);
