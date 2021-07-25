
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static Dictionary<string, GameObject> _loadedParts = new Dictionary<string, GameObject>();

    private int X = 0;
    private int Y = 0;

    private float MapSize = 694f;

    public GameObject MapPartPrefab;

    void Awake()
    {
        MapPartPrefab = (GameObject)Resources.Load("Prefabs/Map/MapPart", typeof(GameObject));
    }

    void Start()
    {
        if (_loadedParts.Count == 0)
        {
            LoadPart(0, 0);
        }
    }

    void FixedUpdate()
    {
        
        if (_loadedParts.Count > 0)
        {
            AroundCheck();
        }
    }


    //checking all closest cells around current map cell to load map parts
    public void AroundCheck()
    {
        for (int y = Y-1; y < Y+2; y++)
        {
            for (int x = X-1; x < X+2; x++)
            {
                print($"{x},{y}");
                if (!_loadedParts.ContainsKey($"{x},{y}")) //searching for non load map part by (x,y). around the currrent cell
                {
                    LoadPart(x, y);
                }
            }
        }
    }

    private void LoadPart(int x, int y)
    {
        GameObject MapPart = Instantiate(MapPartPrefab);
        MapPart.GetComponent<MapPart>().MapSize = MapSize;
        MapPart.GetComponent<MapPart>().SetIndex(x, y);
        _loadedParts.Add($"{x},{y}", MapPart);
    }
}
