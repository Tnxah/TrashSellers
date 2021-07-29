using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    GameObject GameManagerObject;

    MapManager MapManager;
    GameManager GameManager;

    void Start()
    {
        GameManagerObject = GameObject.FindGameObjectWithTag("GameManager");

        MapManager = GameManagerObject.GetComponent<MapManager>();
        GameManager = GameManagerObject.GetComponent<GameManager>();
    }

    public Vector2 currentIndex;

    void Update()
    {
        if (GPS.Instance.isInit && GPS.Instance.ableToGetCoordinates)
        {
            transform.position = CoordinateRecounter.Recount(GPS.Instance.latitude, GPS.Instance.longitude);
        }

        MapManager.SetIndex(currentIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MapPart"))
        {
            currentIndex = other.GetComponent<MapPart>().index;
        }
    }


    //diraction = (oldPos - currPos);

    //    oldPos = currPos;
}
