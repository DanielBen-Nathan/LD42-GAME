using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speedToPly;
    public float speedRand;
    private int mode=0;//0 for select new mode, 1 for move towards, 2 for random
   

    public float timeInModeMin;
    public float timeInModeMax;

    
    private float walkX;
    private float walkY;
    private bool selectRand = true;
    private GameObject archer;
    private bool ready = true;
    // Use this for initialization
    void Start () {
        archer = GameObject.Find("archer");
    }
	
	// Update is called once per frame
	void Update () {
       
        transform.rotation = Quaternion.identity;
        if (mode==0) {
            mode = Random.Range(0, 4);
           
        }
        if (mode == 1 || mode==3)
        {
            if (!archer.GetComponent<Archer>().dead)
            {
                Vector2 archerPos = archer.transform.position;
                transform.position = Vector2.MoveTowards(transform.position, archerPos, speedToPly * Time.deltaTime);
                if (ready)
                {
                    StartCoroutine(TimeInMode());
                    ready = false;
                }

            }
            else {
                mode = 2;
            }
            
          

        }
        if (mode == 2)
        {
            if (selectRand) {
                walkX = Random.Range(-100, 100);
                walkY = Random.Range(-100, 100);
                selectRand = false;
            }
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(walkX,walkY), speedRand * Time.deltaTime);
            if (ready) {
                StartCoroutine(TimeInMode());
                ready = false;
            }
          
        }


        }
    IEnumerator TimeInMode()
    {


        float time = Random.Range(timeInModeMin, timeInModeMax);
       
        yield return new WaitForSeconds(time);
       
        mode = 0;
        selectRand = true;
        ready = true;


    }
}
