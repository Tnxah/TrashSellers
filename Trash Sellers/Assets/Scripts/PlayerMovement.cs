using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Transform player;

    void Start()
    {
        player = gameObject.GetComponent<Transform>();
    }

   
    void Update()
    {
        player.position = new Vector3(GPS.Instance.latitude,0,GPS.Instance.longitude);
    }
}
