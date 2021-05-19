using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector2 oldPos = Vector2.zero;
    Vector2 currPos = Vector2.zero;

    Vector2 diraction = Vector2.zero;
    Vector3 iniRef = Vector3.zero;

    private bool able = false;
    void Start()
    {
        StartCoroutine(Init());

    }

   
    void Update()
    {
        //player.position = iniRef;
        if (able)
        {
  gameObject.GetComponent<CoordinateRecounter>().Recount();
        }
      
    }

    IEnumerator Init()
    {
        yield return new WaitUntil(() => GPS.Instance.ableToGetCoordinates);
        able = true;
        currPos = new Vector2(GPS.Instance.latitude, GPS.Instance.longitude);

        diraction = (oldPos - currPos);

        oldPos = currPos;

        iniRef.x = (float)((currPos.y * 20037508.34 / 180) / 100);
        iniRef.z = (float)(System.Math.Log(System.Math.Tan((90 + currPos.x) * System.Math.PI / 360)) / (System.Math.PI / 180));
        print(iniRef.z);
        iniRef.z = (float)((iniRef.z * 20037508.34 / 180) / 100);
    }

    public Vector3 GetIniRef()
    {
        return iniRef;
    }
}
