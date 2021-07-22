using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 oldPos = Vector2.zero;
    Vector2 currPos = Vector2.zero;

    Vector2 diraction = Vector2.zero;
    //Vector3 iniRef = Vector3.zero;

    private bool able = false;
    void Start()
    {
        //StartCoroutine(Init());
    }

   
    void Update()
    {
        
        if (able)
        {
            transform.position = CoordinateRecounter.Recount(GPS.Instance.latitude, GPS.Instance.longitude);
        }    
    }

    

    //public Vector3 GetIniRef()
    //{
    //    return iniRef;
    //}
}
