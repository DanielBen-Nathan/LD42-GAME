using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject skeleton;
    

   
    public float spawnRate;
    public float spawnRateInc;

    public float scaleMax;
    public float scaleMin;

    private bool ready = true;
    private MapData mapdata;

    private Archer archer;
    private bool stop = false;
    // Use this for initialization
    void Start () {
        mapdata = GetComponent<MapData>();
        archer = GameObject.Find("archer").GetComponent<Archer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (archer.dead)
        {
            stop = true;
        }
        if (ready&& !stop) {

            float randomX = Random.Range(mapdata.mapMinX, mapdata.mapMaxX);
            float randomY = Random.Range(mapdata.mapMinY, mapdata.mapMaxY);
            Vector2 randomVector = new Vector2(randomX, randomY);
            
            //Collider2D[] inRange = Physics2D.OverlapCircleAll(randomVector, 1);
          
            GameObject skeletonObj = Instantiate(skeleton, randomVector, transform.rotation);

            float randScale = Random.Range(scaleMin, scaleMax);
            skeletonObj.transform.localScale = new Vector3(randScale, randScale, 0);
            skeletonObj.GetComponent<Rigidbody2D>().mass = randScale / 10;
            StartCoroutine(WaitBetweenSpawns());
        }




	}

    IEnumerator WaitBetweenSpawns()
    {



        ready = false;
        yield return new WaitForSeconds(1/spawnRate);
        spawnRate += spawnRateInc;
        ready = true;


    }
}
