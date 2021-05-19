﻿using Google.Maps.Coord;
using Google.Maps.Event;
using Google.Maps.Examples.Shared;
using System.Collections;
using UnityEngine;

namespace Google.Maps.Examples {

  [RequireComponent(typeof(MapsService))]
  public class BasicExample : MonoBehaviour {
        MapsService mapsService;
        //LatLng LatLng = new LatLng(40.6892199, -74.044601);
        LatLng LatLng = new LatLng(0,0);

        bool load = false;


        private void Start() {
        mapsService = GetComponent<MapsService>();      
            StartCoroutine(LoadMap());
        }

        void Update()
        {
            //LatLng = new LatLng(GPS.Instance.latitude, GPS.Instance.longitude);
        }    

        public void SetLatLan(Vector2 coords)
        {
            LatLng = new LatLng(coords.x, coords.y);
            load = true;
        }

        public void OnLoaded(MapLoadedArgs args) {
      

        }
        IEnumerator LoadMap() {
            yield return new WaitUntil(() => load);
            mapsService.InitFloatingOrigin(LatLng);
            mapsService.Events.MapEvents.Loaded.AddListener(OnLoaded);
            mapsService.LoadMap(ExampleDefaults.DefaultBounds, ExampleDefaults.DefaultGameObjectOptions);
        }
  }
}
