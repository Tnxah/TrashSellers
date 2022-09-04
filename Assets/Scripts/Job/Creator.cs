using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : Job
{
    public Creator()
    {
        type = JobType.Creator;
        level = PlayfabStatisticsManager.GetStat(StatisticsKeys.creatorLevelKey);
    }

    public override void ApplyJobProperties()
    {
        throw new System.NotImplementedException();
    }

    public override bool Unlock()
    {
        unlocked = true;
        return unlocked;
    }
}
