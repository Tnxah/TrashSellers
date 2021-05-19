using Google.Maps.Examples;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    public TextMeshProUGUI coordinates;
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;

    public bool ableToGetCoordinates = false;

    public float checkDelay = 1.5f;
    float lastCheck;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    void Start()
    {
        BasicExample map = (BasicExample)GameObject.Instantiate(Resources.Load("Prefabs/MapPart"));
        //map.SetLatLan();
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

        
        Input.location.Start(5, 5);
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

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        ableToGetCoordinates = true;

        yield break;
    }

    private void Update()
    {
        if (ableToGetCoordinates && Time.time > (checkDelay + lastCheck))
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            coordinates.text = "lat: " + latitude + "\n" + "lon: " + longitude;

            lastCheck = Time.time;
        }
       
    }
}
