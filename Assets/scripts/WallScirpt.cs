using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScirpt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemyProjectile" || col.tag == "playerProjectile") {
            Destroy(col.gameObject);
        }
    }
   
    
}
