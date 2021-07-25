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
    [SerializeField]
    public TextMeshProUGUI coordinates;
    [SerializeField]
    public static GPS Instance { set; get; }

    public float latitude //= 0f;
    = 52.20925f;
    public float longitude //= 0f;
    = 20.97479f;
    public float checkDelay = 1f;
    private float lastCheck;

    [SerializeField]
    public bool ableToGetCoordinates = false;
    [SerializeField]
    public bool isInit = false;



    GameObject map;
    GameObject player;

    Vector2 oldPos = Vector2.zero;
    Vector2 currPos = Vector2.zero;
    Vector2 diraction = Vector2.zero;
    [SerializeField]
    public Vector3 iniRef = Vector3.zero;


    private void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
       
        
    }

    void Start()
    {
        StartCoroutine(StartLocationService());
        //map = (GameObject)Instantiate(Resources.Load("Prefabs/MapPartOld", typeof(GameObject)));
        //player = GameObject.FindGameObjectWithTag("Player");
        //player.transform.gameObject.GetComponentInChildren<MapLoader>().MapsService = map.GetComponent<MapsService>();
        //StartCoroutine(Init());
    }

    private IEnumerator StartLocationService()
    {
        yield return new WaitForSeconds(2);

        //if (!Input.location.isEnabledByUser)
        //{
        //    Debug.Log("GPS is disabled");
        //    yield break;
        //}
        //else { Debug.Log("GPS is enabled"); }


        //Input.location.Start(5, 5);
        //yield return new WaitForSeconds(1);
        //int maxWait = 20;
        //while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        //{
        //    yield return new WaitForSeconds(1);
        //    maxWait--;
        //}
        //if (maxWait <= 0)
        //{
        //    Debug.Log("Time out");
        //    yield break;
        //}
        //if (Input.location.status == LocationServiceStatus.Failed)
        //{
        //    Debug.Log("Unable to determin device location");
        //    yield break;
        //}

        //latitude = Input.location.lastData.latitude;
        //longitude = Input.location.lastData.longitude;

        //map.GetComponent<BasicExample>().SetLatLan(new Vector2(latitude, longitude));

        ableToGetCoordinates = true;

        Init();

        yield break;
    }

    private void Update()
    {
        //if (ableToGetCoordinates && Time.time > (checkDelay + lastCheck))
        //{
        //    latitude = Input.location.lastData.latitude;
        //    longitude = Input.location.lastData.longitude;

        //    coordinates.text = "lat: " + latitude + "\n" + "lon: " + longitude;

        //    lastCheck = Time.time;
        //}

    }

    void Init()
    {
        //yield return new WaitUntil(() => ableToGetCoordinates);
        
        currPos = new Vector2(latitude, longitude);

        iniRef.x = (float)((currPos.y * 20037508.34f / 180f) / 100f);
        iniRef.z = (float)(System.Math.Log(System.Math.Tan((90f + currPos.x) * System.Math.PI / 360f)) / (System.Math.PI / 180f));
        iniRef.z = (float)((iniRef.z * 20037508.34f / 180f) / 100f);
        isInit = true;
    }
}
