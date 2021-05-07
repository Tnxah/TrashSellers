using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMapLoader : MonoBehaviour
{

    Text text;
    const string Key = "lTv416egDJ0cfeS6StuU2RiLW69xoAGQ";

    Boolean loaded = true;

    public Renderer mapRenderer;
    Vector2 PlayerPosition;

    int _zoom = 16;
    string _maptype = "map";
    string _url;

    private void Awake()
    {
       
    }
    void Start()
    {
        PlayerPosition = new Vector2(GPS.Instance.latitude, GPS.Instance.longitude);
        StartCoroutine(LoadMapIfPosible());
    }

    private void LoadMap()
    {


        _url = "http://www.mapquestapi.com/staticmap/v4/getmap?key=" + Key +
"&size=3840,3840&zoom=" + _zoom +
"&type=" + _maptype +
"&center=" + PlayerPosition.x.ToString().Replace(",",".") + "," + PlayerPosition.y.ToString().Replace(",", ".");
        gameObject.transform.position = new Vector3(PlayerPosition.x, 0, PlayerPosition.y);
        Debug.Log(_url);
        StartCoroutine(LoadImage());
    }


    IEnumerator LoadMapIfPosible()
    {
        yield return new WaitUntil(() => GPS.Instance.ableToGetCoordinates);
        yield return new WaitUntil(() => PlayerPosition.x > 0 || PlayerPosition.y > 0);
        LoadMap();
    }

    private IEnumerator LoadImage()
    {
        loaded = false;
        WWW www = new WWW(_url);

        while (!www.isDone)
        {
            //Debug.Log("image loading: " + www.progress);
            yield return null;
        }
        if(www.error == null)
        {
            Debug.Log("Map is loaded");
            mapRenderer.material.mainTexture = null;
            Texture2D tmp;
            tmp = new Texture2D(1920, 1920, TextureFormat.RGB565, false);
            mapRenderer.material.mainTexture = tmp;
            www.LoadImageIntoTexture(tmp);

            
        }
        else
        {
            Debug.Log("Something went wrong");
            Debug.Log(www.error);
            
        }
        loaded = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
           PlayerPosition = new Vector2(GPS.Instance.latitude, GPS.Instance.longitude);
           // LoadMap();
           // text.text = PlayerPosition.x.ToString() + " / " + PlayerPosition.y.ToString();
        
       
    }
}
