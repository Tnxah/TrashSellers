
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject Player;

    private static Dictionary<string, GameObject> _loadedParts = new Dictionary<string, GameObject>();

    private int X;
    private int Y;

    public float MapSize;

    GameObject MapPartPrefab;

    void Awake()
    {
        MapPartPrefab = (GameObject)Resources.Load("Prefabs/Map/MapPart", typeof(GameObject));
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        if (_loadedParts.Count == 0)
        {
            LoadPart(0, 0);
        }
    }

    void Update()
    {

    }


    //checking all closest cells around current map cell to load map parts
    public void AroundCheck()
    {
        for (int y = Y--; y < Y++; y++)
        {
            for (int x = X--; x < X++; x++)
            {
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
