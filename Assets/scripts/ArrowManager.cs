using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour {
    public float range;
    public int damage;
    public Vector3 pos;
    public float force;
	// Use this for initialization
	void Start () {
        StartCoroutine(WaitDie());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator WaitDie()
    {

        

        yield return new WaitForSeconds(range);

        Destroy(gameObject);



    }
}
