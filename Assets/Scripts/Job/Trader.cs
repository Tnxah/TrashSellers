using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : Job
{
    private const int unlockLevel = 10;

    public Trader()
    {
        type = JobType.Trader;
        level = PlayfabStatisticsManager.GetStat(StatisticsKeys.traderLevelKey);
    }

    public override void ApplyJobProperties()
    {
        throw new System.NotImplementedException();
    }

    public override bool Unlock()
    {
        var playerLevel = PlayfabStatisticsManager.GetStat(StatisticsKeys.playerLevelKey);

        if (!unlocked && playerLevel >= unlockLevel)
            unlocked = true;

        return unlocked;
    }
}
