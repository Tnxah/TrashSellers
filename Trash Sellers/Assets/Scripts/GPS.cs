using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    Text text;
   

    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;

    private bool ableToGetCoordinates = false;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    void Start()
    {
        
    }

    private IEnumerator StartLocationService()
    {
        yield return new WaitForSeconds(2);

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS is disabled");
            yield break;
        }
        else { Debug.Log("GPS is enabled"); }

        
        Input.location.Start();
        yield return new WaitForSeconds(1);
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait <= 0)
        {
            Debug.Log("Time out");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }


        ableToGetCoordinates = true;

        yield break;
    }

    private void Update()
    {
        if (ableToGetCoordinates)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            text.text = GPS.Instance.latitude.ToString() + " / " + GPS.Instance.longitude.ToString();
        }
       
    }
}
