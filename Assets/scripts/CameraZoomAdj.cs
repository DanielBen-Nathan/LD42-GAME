using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomAdj : MonoBehaviour {

	// Use this for initialization
	void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        float orth = 1920 / currentAspect / 220;
        GetComponent<Camera>().orthographicSize = orth;
    }
   
}
