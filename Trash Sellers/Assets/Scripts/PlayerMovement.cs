using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    void Update()
    {
        if (GPS.Instance.isInit)
        {
            transform.position = CoordinateRecounter.Recount(GPS.Instance.latitude, GPS.Instance.longitude);
        }    
    }




    //diraction = (oldPos - currPos);

    //    oldPos = currPos;
}
