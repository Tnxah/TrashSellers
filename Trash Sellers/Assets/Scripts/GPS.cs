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
    public TextMeshProUGUI coordinates;
    public static GPS Instance { set; get; }

    public float latitude;
    public float longitude;

    public bool ableToGetCoordinates = false;

    public float checkDelay = 1f;
    float lastCheck;

    GameObject map;
    GameObject player;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    void Start()
    {
        map = (GameObject)Instantiate(Resources.Load("Prefabs/MapPart", typeof(GameObject)));
        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.gameObject.GetComponentInChildren<MapLoader>().MapsService = map.GetComponent<MapsService>();
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

        map.GetComponent<BasicExample>().SetLatLan(new Vector2(latitude, longitude));

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
