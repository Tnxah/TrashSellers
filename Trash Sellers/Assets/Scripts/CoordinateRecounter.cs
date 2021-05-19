using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateRecounter : MonoBehaviour
{
    Vector3 position = Vector3.zero;
    float lat, lon;

    Vector3 iniRef;
    Transform player;

    void Start()
    {
        player = gameObject.transform;
        iniRef = gameObject.GetComponent<PlayerMovement>().GetIniRef();
    }

    void Update()
    {
        lat = GPS.Instance.latitude;
        lon = GPS.Instance.longitude;
    }

    public void Recount()
    {
        iniRef = gameObject.GetComponent<PlayerMovement>().GetIniRef();
        position.x = (float)(((lon * 20037508.34 / 180) / 100) - iniRef.x);
        position.z = (float)(Mathf.Log(Mathf.Tan((90 + lat) * Mathf.PI / 360)) / (Mathf.PI / 180));
        position.z = (float)(((position.z * 20037508.34 / 180) / 100) - iniRef.z);

        //sizing
        position.x *= 121f;
        position.z *= 121f;

        player.position = position;
    }
}
