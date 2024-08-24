namespace VerbConjugationTrainer;

using System.Collections.Generic;

public static class ConjugatedVerbs
{
    public static Dictionary<string, List<(string en, string esp)>> verbs = new ()
    {
        //{ "hablar - to speak",
        //    [
        //        //indicative present
        //        ("i speak", "hablo"),
        //        ("you speak", "hablas"),
        //        ("he/she speaks", "habla"),
        //        ("we speak", "hablamos"),
        //        ("they/you speak", "hablan"),
        //        //indicative preterite
        //        ("i spoke", "hablé"),
        //        ("you spoke", "hablaste"),
        //        ("he/she spoke", "habló"),
        //        ("we spoke", "hablamos"),
        //        ("they/you spoke", "hablaron"),
        //        //indicative imperfect
        //        ("i was speaking", "hablaba"),
        //        ("you were speaking", "hablabas"),
        //        ("he/she was speaking", "hablaba"),
        //        ("we were speaking", "hablámos"),
        //        ("they/you were speaking", "hablaban"),
        //        //indicative future
        //        ("i will speak", "hablaré"),
        //        ("you will speak", "hablarás"),
        //        ("he/she will speak", "hablará"),
        //        ("we will speak", "hablaremos"),
        //        ("they/you will speak", "hablarán"),
        //        //progressive present
        //        ("i'm speaking", "estoy hablando"),
        //        ("you're speaking", "estás hablando"),
        //        ("he/she is speaking", "está hablando"),
        //        ("we're speaking", "estamos hablando"),
        //        ("they're/you're speaking", "están hablando"),
        //    ]
        //},
        { "ser - to be (long lasting)",
            [
                //indicative present
                ("i am", "soy"),
                ("you are", "eres"),
                ("he/she is", "es"),
                ("we are", "somos"),
                ("they/you are", "son"),
                //indicative preterite
                ("i was", "fui"),
                ("you were", "fuiste"),
                ("he/she was", "fue"),
                ("we were", "fuimos"),
                ("they/you were", "fueron"),
                //indicative imperfect
                ("i was being", "era"),
                ("you were being", "eras"),
                ("he/she was being", "era"),
                ("we were being", "éramos"),
                ("they/you were being", "eran"),
                //indicative conditional
                ("i'd be", "sería"),
                ("you'd be", "serías"),
                ("he/she would be", "sería"),
                ("we would be", "seríamos"),
                ("they/you would be", "serían"),
                //indicative future
                ("i will be", "seré"),
                ("you will be", "serás"),
                ("he/she will be", "será"),
                ("we will be", "seremos"),
                ("they/you will be", "serán"),
                //subjunctive present
                ("that/if i am", "sea"),
                ("that/if you are", "seas"),
                ("that/if he/she is", "sea"),
                ("that/if we are", "seamos"),
                ("that/if they/you are", "sean"),
                //subjunctive imperfect
                ("that/if i was", "fuera"),
                ("that/if you were", "fueras"),
                ("that/if he/she was", "fuera"),
                ("that/if we were", "fuéramos"),
                ("that/if they/you were", "fueran"),
                //progressive present
                //("i am being", "estoy siendo"),
                //("you're being", "estás siendo"),
                //("he/she is being", "está siendo"),
                //("we're speaking being", "estamos siendo"),
                //("they're/you're being", "están siendo"),
                //perfect present
                //("i have been", "he sido"),
                //("you've been", "has sido"),
                //("he/she has been", "ha sido"),
                //("we have been", "hemos sido"),
                //("they/you have been", "han sido"),
            ]
        },
        { "estar - to be (temporary)",
            [
                //indicative present
                ("i am", "estoy"),
                ("you are", "estás"),
                ("he/she is", "está"),
                ("we are", "estamos"),
                ("they/you are", "están"),
                //indicative preterite
                ("i was", "estuve"),
                ("you were", "estuviste"),
                ("he/she was", "estuvo"),
                ("we were", "estuvimos"),
                ("they/you were", "estuvieron"),
                //indicative imperfect
                ("i was being", "estaba"),
                ("you were being", "estabas"),
                ("he/she was being", "estaba"),
                ("we were being", "estábamos"),
                ("they/you were being", "estaban"),
                //indicative conditional
                ("i would be", "estaría"),
                ("you would be", "estarías"),
                ("he/she would be", "estaría"),
                ("we would be", "estaríamos"), 
                ("they/you would be", "estarían"), 
                //indicative future
                ("i will be", "estaré"),
                ("you will be", "estarás"),
                ("he/she will be", "estará"),
                ("we will be", "estaremos"),
                ("they/you will be", "estarán"),
                //subjunctive present
                ("that/if i am", "esté"),
                ("that/if you are", "estés"),
                ("that/if he/she is", "esté"),
                ("that/if we are", "estemos"),
                ("that/if you/they are", "estén"),
                //subjunctive imperfect
                ("that/if i was", "estuviera"),
                ("that/if you were", "estuvieras"),
                ("that/if he/she was", "estuviera"),
                ("that/if we was", "estuviéramos"),
                ("that/if you/they were", "estuvieran"),
                //progressive present - NOT USED
                //perfect present
                //("i have been", "he estado"),
                //("you have been", "has estado"),
                //("he/she has been", "ha estado"),
                //("we have been", "hemos estado"),
                //("they/you have been", "han estado"),
            ]
        },
        { "hacer - to do",
            [
                //indicative present
                ("i do", "hago"),
                ("you do", "haces"),
                ("he/she does", "hace"),
                ("we do", "hacemos"),
                ("they/you are", "hacen"),
                //indicative preterite
                ("i did", "hice"),
                ("you did", "hiciste"),
                ("he/she did", "hizo"),
                ("we did", "hicimos"),
                ("they/you did", "hicieron"),
                //indicative imperfect
                ("i was doing", "hacía"),
                ("you were doing", "hacías"),
                ("he/she was doing", "hacía"),
                ("we were doing", "hacíamos"),
                ("they/you were doing", "hacían"),
                //indicative conditional
                ("i would do", "haría"),
                ("you would do", "harías"),
                ("he/she would do", "haría"),
                ("we would do", "haríamos"),
                ("they/you would do", "harían"),
                //indicative future
                ("i will do", "haré"),
                ("you will do", "harás"),
                ("he/she will do", "hará"),
                ("we will do", "haremos"),
                ("they/you will do", "harán"),
                //subjunctive present
                ("that/if i do", "haga"),
                ("that/if you do", "hagas"),
                ("that/if he/she does", "haga"),
                ("that/if we do", "hagamos"),
                ("that/if they/you do", "hagan"),
                //subjunctive imperfect
                ("that/if i did", "hiciera"),
                ("that/if you did", "hicieras"),
                ("that/if he/she did", "hiciera"),
                ("that/if we did", "hiciéramos"),
                ("that/if they/you did", "hicieran"),
                //perfect present
                //progressive present
                //("i'm doing", "estoy haciendo"),
                //("you're doing", "estás haciendo"),
                //("he/she is doing", "está haciendo"),
                //("we're doing", "estamos haciendo"),
                //("they/you are doing", "están haciendo"),
            ]
        },
    };
}
