using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Shop.instance.UpdateCatalogItems();
        StartCoroutine(JobsInit());
    }

    private IEnumerator JobsInit()
    {
        yield return new WaitUntil(() => PlayfabStatisticsManager.loaded);

        JobManager.Init();
    }

    void Update()
    {
        if (GPS.instance.isInit)
        {
            GetComponent<MapManager>().enabled = true;
        }
    }
}
