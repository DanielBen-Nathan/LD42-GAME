using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour {
    public Slider bar;
	// Use this for initialization
	void Start () {
        bar = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetMaxValue(int value)
    {
        bar.maxValue = value;

    }

    public void SetValue(int value) {
        bar.value = value;

    }
}
