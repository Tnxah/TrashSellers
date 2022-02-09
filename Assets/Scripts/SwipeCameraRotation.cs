using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCameraRotation : MonoBehaviour
{
    private Touch touch;
    public float sensivity = 0.1f;

    private Quaternion rotation;


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase.Equals(TouchPhase.Moved))
            {
                rotation = Quaternion.Euler(0f,-touch.deltaPosition.x * sensivity, 0f);
                transform.rotation *= rotation;
            }
        }
    }
}
