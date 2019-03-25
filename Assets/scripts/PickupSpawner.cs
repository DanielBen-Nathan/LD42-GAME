using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    public GameObject pickup;
   

    public float spawnRate;
  

    private bool ready=true;
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
       
        if (archer.dead) {
            stop = true;
        }

        if (ready && !stop)
        {
            float randomX = Random.Range(mapdata.mapMinX, mapdata.mapMaxX);
            float randomY = Random.Range(mapdata.mapMinY, mapdata.mapMaxY);
            Vector2 randomVector = new Vector2(randomX, randomY);
            Instantiate(pickup, randomVector, transform.rotation);
            StartCoroutine(WaitBetweenSpawns());



        }
    }

    IEnumerator WaitBetweenSpawns()
    {



        ready = false;
        yield return new WaitForSeconds(1 / spawnRate);
     
        ready = true;


    }
}
