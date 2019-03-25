using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    public float effectiveness;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "playerProjectile")
        {

            ArrowManager arrowManager = col.gameObject.GetComponent<ArrowManager>();
          
          
            Vector2 dir = (col.gameObject.transform.position - arrowManager.pos).normalized;
               
            GetComponent<Rigidbody2D>().AddForce(dir * arrowManager.force);
                


            


            Destroy(col.gameObject);


        }
    }
}
