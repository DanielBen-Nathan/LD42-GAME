using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int scoreNum;
  
    public GameObject scoreObj;
    public Text scoreText;
    // Use this for initialization
    void Start () {
        scoreText = scoreObj.GetComponent<Text>();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddScore(int value) {
        scoreNum += value;
        scoreText.text = "SCORE: " + scoreNum;

    }

}
