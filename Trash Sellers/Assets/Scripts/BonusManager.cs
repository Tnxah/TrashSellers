using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BonusManager
{
    private static List<EBonuses> _activeBonuses;
    private static Dictionary<EBonuses, Func<EBonuses, float>> _enumValues =
        new Dictionary<EBonuses, Func<EBonuses, float>>()
        {
            //{ EBonuses.PsychoDamageDecreasing, new Func<EBonuses, float>(Increas) }
        };



    static void Add(EBonuses bonus)
    {
        _enumValues[bonus].DynamicInvoke();
    }

    static void Increas(EBonuses bonus, float percent)
    {

    }
}
