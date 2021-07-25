using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateRecounter : MonoBehaviour
{
    static Vector3 position = Vector3.zero;
    static float lat, lon;

    static Vector3 iniRef;

    void Start()
    {
        
    }
    public static Vector3 Recount(float lat, float lan)
    {
        iniRef = GPS.Instance.iniRef;

        position.x = (float)(((lon * 20037508.34f / 180f) / 100f) - iniRef.x);
        position.z = (float)(Mathf.Log(Mathf.Tan((90f + lat) * Mathf.PI / 360f)) / (Mathf.PI / 180f));
        position.z = (float)(((position.z * 20037508.34f / 180f) / 100f) - iniRef.z);

        //sizing
        position.x *= 121f;
        position.z *= 121f;

        return new Vector3(position.x, 0, position.z);
    }

    public static Vector2 RecountReverse(float x, float z)
    {
        x /= 121f;
        z /= 121f;

        iniRef = GPS.Instance.iniRef;

        lon = (float)(((x + iniRef.x) * 100f) * 180f / 20037508.34f);
        z = (float)(((z + iniRef.z) * 100f) * 180f / 20037508.34f);
        lat = (float)((360f / Mathf.PI) * Mathf.Atan(Mathf.Pow((float)Math.E, z * (Mathf.PI / 180f)))) - 90f;

        print(lon);
        print(lat);
        return new Vector2(lat, lon);
    }

}
