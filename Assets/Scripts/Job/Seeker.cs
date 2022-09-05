using System;
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
        unlocked = Convert.ToBoolean(PlayfabStatisticsManager.GetStat(StatisticsKeys.seekerUnlockedKey));
    }

    public override void ApplyJobProperties()
    {
        SpawnController.instance.spawnChance = 50 * spawnChanceMultiplyer[level];
        Debug.Log(level);
    }

    public override void LevelUp()
    {
        level++;

        ApplyJobProperties();

        //GetReward();

        PlayfabStatisticsManager.SaveStat(StatisticsKeys.seekerLevelKey, level);
    }

    public override bool Unlock()
    {
        var playerLevel = PlayfabStatisticsManager.GetStat(StatisticsKeys.playerLevelKey);

        if (playerLevel >= 2)
        {
            unlocked = true;
            PlayfabStatisticsManager.SaveStat(StatisticsKeys.seekerUnlockedKey, Convert.ToInt32(unlocked));
        }

        return unlocked;
    }
}
