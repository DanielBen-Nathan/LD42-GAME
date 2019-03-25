using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {
    private bool ready = false;
    public float speed;
   
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (ready)
        {
            GameObject.Find("bow").GetComponent<ShootArrows>().enabled = false;
            GameObject cam = GameObject.Find("Main Camera");
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(0, 0,-10), speed * Time.deltaTime);
            if (cam.transform.position == new Vector3(0, 0, -10)) {
                ready = false;
                GameObject.Find("bow").GetComponent<ShootArrows>().enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "playerProjectile")
        {
            ready = true;



        }
    }
}
