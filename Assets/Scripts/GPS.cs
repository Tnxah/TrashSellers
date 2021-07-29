using Google.Maps;
using Google.Maps.Examples;
using Google.Maps.Loading;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour
{
    //52.20925
    //20.97479
    public TextMeshProUGUI coordinates;
    [HideInInspector]
    public static GPS Instance { set; get; }

    public float latitude = 0f;
    //= 52.20925f;
    public float longitude = 0f;
    //= 20.97479f;
    public float checkDelay = 1f;
    private float lastCheck;

    [HideInInspector]
    public bool ableToGetCoordinates = false;
    [HideInInspector]
    public bool isInit = false;

    public bool HardCodeCoordinates;


    //GameObject map;
    //GameObject player;

    Vector2 oldPos = Vector2.zero;
    Vector2 currPos = Vector2.zero;
    Vector2 diraction = Vector2.zero;
    [HideInInspector]
    public Vector3 iniRef = Vector3.zero;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
       
        
    }

    void Start()
    {
        StartCoroutine(StartLocationService());
        
    }

    private IEnumerator StartLocationService()
    {
        yield return new WaitForSeconds(2);
        if (!HardCodeCoordinates)
        {
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
        }

        ableToGetCoordinates = true;

        Init();

        yield break;
    }

    private void Update()
    {
        if (!HardCodeCoordinates && ableToGetCoordinates && Time.time > (checkDelay + lastCheck))
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            coordinates.text = "lat: " + latitude + "\n" + "lon: " + longitude;

            lastCheck = Time.time;
        }

    }

    void Init()
    {        
        currPos = new Vector2(latitude, longitude);
        print(latitude + " " + longitude +"Init latlan");

        iniRef.x = (float)((longitude * 20037508.34f / 180f) / 100f);
        iniRef.z = (float)(System.Math.Log(System.Math.Tan((90f + latitude) * System.Math.PI / 360f)) / (System.Math.PI / 180f));
        iniRef.z = (float)((iniRef.z * 20037508.34f / 180f) / 100f);
        isInit = true;
    }
}
