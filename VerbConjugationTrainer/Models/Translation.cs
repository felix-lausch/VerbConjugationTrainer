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
    Translation ThirdPersonPlural);

public record Verb(Translation RegularForm, List<Conjugations> Conjugations);
