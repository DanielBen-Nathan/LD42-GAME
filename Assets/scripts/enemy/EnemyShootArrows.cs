using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootArrows : MonoBehaviour {
    public GameObject arrow;
    public float speed;
    public float fireRate;
    public int damage;
    public float range;
    public float spotRange;
    public float randomDev;
    private bool ready = true;
    private GameObject archer;
    // Use this for initialization
    void Start () {
        archer = GameObject.Find("archer");
	}
	
	// Update is called once per frame
	void Update () {
        if (ready && !archer.GetComponent<Archer>().dead) {
            Vector3 archerPos = archer.transform.position;
            Vector2 dir = (transform.position - archerPos);
            float distance = dir.magnitude;
            if (distance <= spotRange)
            {
                GameObject arrowObj = Instantiate(arrow, transform.position, transform.rotation);


                float randX = Random.Range(-randomDev, randomDev);
                float randY = Random.Range(-randomDev, randomDev);
                archerPos = new Vector3(archerPos.x+randX, archerPos.y+randY);
                Vector3 dir2 = (transform.position - archerPos).normalized;
                


                arrowObj.GetComponent<Rigidbody2D>().AddForce(-dir2 * speed);
               
                arrowObj.GetComponent<ArrowManager>().range = range;
                arrowObj.GetComponent<ArrowManager>().damage = damage;
                StartCoroutine(WaitBetweenShots());


            }
        
        }
    }

    IEnumerator WaitBetweenShots()
    {

        ready = false;

        yield return new WaitForSeconds(1 / fireRate);

        ready = true;



    }
}
