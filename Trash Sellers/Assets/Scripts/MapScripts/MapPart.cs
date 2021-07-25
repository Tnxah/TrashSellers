using Google.Maps;
using Google.Maps.Examples.Shared;
using Google.Maps.Coord;
using Google.Maps.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(MapsService))]
public class MapPart : MonoBehaviour
{
    MapsService mapsService;
    
    LatLng LatLng = new LatLng(0, 0);

    private bool _load = false;

    public float MapSize;
    
    void Start()
    {
        mapsService = GetComponent<MapsService>();
        StartCoroutine(MapLoading());
    }
    public void SetLatLan(Vector2 coords)
    {
        //print(coords);
        LatLng = new LatLng(coords.x, coords.y);
        _load = true;
    }

    public void SetIndex(int x, int y)
    {
        
        float X = x * MapSize*2; // почему то * 2
        float Y = y * MapSize*2;

        transform.position = new Vector3(X/2,0,Y/2);

        if (!GPS.Instance.isInit)
        {
            print("Not init yet");
        }

        Vector2 coords = CoordinateRecounter.RecountReverse(X, Y);

        SetLatLan(coords);
    }

    IEnumerator MapLoading()
    {
        yield return new WaitUntil(() => _load);
        print("Map part loading started in " + LatLng);
        mapsService.InitFloatingOrigin(LatLng);
        mapsService.Events.MapEvents.Loaded.AddListener(OnLoaded);
        mapsService.LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
    }

    public void OnLoaded(MapLoadedArgs args)
    {


    }
}
