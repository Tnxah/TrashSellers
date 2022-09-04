using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfabStatisticsManager
{
    public static List<StatisticValue> statistics;

    public static bool loaded = false;

    public static void LoadStatistics()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStatistics,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }

    public static void OnGetStatistics(GetPlayerStatisticsResult result)
    {
        statistics = new List<StatisticValue>();
        statistics = result.Statistics;

        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);

        loaded = true;
    }

    public static int GetStat(string statisticKey)
    {
        if (!loaded)
            LoadStatistics();

        return statistics.Find(stat => stat.StatisticName == statisticKey).Value;
    }

    public static void SaveStat(string statisticKey, int value)
    {
        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
            new StatisticUpdate { StatisticName = statisticKey, Value = value },
            }
        },
        result => { Debug.Log("User statistics updated"); },
        error => { Debug.LogError(error.GenerateErrorReport()); });
    }
}
