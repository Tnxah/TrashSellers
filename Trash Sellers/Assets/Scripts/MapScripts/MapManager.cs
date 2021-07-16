
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static Dictionary<string, GameObject> _loadedParts;

    private int X;
    private int Y;



    GameObject MapPartPrefab;

    void Awake()
    {
        MapPartPrefab = (GameObject)Resources.Load("Prefabs/Map/MapPart", typeof(GameObject));
    }

    void Start()
    {

    }

    void Update()
    {

    }


    //check all closest cells around current map cell to load map parts
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
        //MapPart.GetComponent< >().SetIndex(x, y); need to add component type
        _loadedParts.Add($"{x},{y}", MapPart);

    }
}
