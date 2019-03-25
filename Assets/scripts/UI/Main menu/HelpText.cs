using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpText : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        if (Application.platform == RuntimePlatform.Android) {
            text.text = "left joystick to move\nRight joystick to shoot\nSkeletons should be dumped in pits for score\nfirerate and health pickups spawn";


        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
