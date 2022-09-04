using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Job
{
    private float[] spawnChanceMultiplyer = {1f, 1.1f, 1.2f, 1.3f};


    public Seeker()
    {
        type = JobType.Seeker;
        level = PlayfabStatisticsManager.GetStat(StatisticsKeys.seekerLevelKey);
    }

    public override void ApplyJobProperties()
    {
        SpawnController.instance.spawnChance = 50 * spawnChanceMultiplyer[level];
    }

    public override bool Unlock()
    {
        var playerLevel = PlayfabStatisticsManager.GetStat(StatisticsKeys.playerLevelKey);

        if (playerLevel >= 2)
            unlocked = true;

        return unlocked;
    }
}
