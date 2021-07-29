using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateRecounter : MonoBehaviour
{
    static Vector3 position = Vector3.zero;
    static float lat, lon;

    static Vector3 iniRef;

    public static Vector3 Recount(float lat, float lon)
    {
        iniRef = GPS.Instance.iniRef;

        position.x = (float)(((lon * 20037508.34f) / 18000f) - iniRef.x);
        position.z = (float)(((Mathf.Log(Mathf.Tan((90f + lat) * Mathf.PI / 360f)) / (Mathf.PI / 180f)) * 1113.19490777778f) - iniRef.z);
        
        //sizing
        position.x *= 60.5f;
        position.z *= 60.5f;

        return new Vector3(position.x, 0, position.z);
    }

    public static Vector2 RecountReverse(float x, float z)
    {
        x /= 60.5f;
        z /= 60.5f;

        iniRef = GPS.Instance.iniRef;

        lon = (float)(((x + iniRef.x) * 100f) * 180f / 20037508.34f);
        lat = (Mathf.Atan(Mathf.Pow((float)Math.E, ((z + iniRef.z) * (Mathf.PI / 180f) / 1113.19490777778f))) / Mathf.PI * 360f) - 90f;

        //print(lon);
        //print(lat);
        return new Vector2(lat, lon);
    }

}