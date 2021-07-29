using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Update()
    {
        if (GPS.Instance.isInit)
        {
            GetComponent<MapManager>().enabled = true;
        }
    }
}
