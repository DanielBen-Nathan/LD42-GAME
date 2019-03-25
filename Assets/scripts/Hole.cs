using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    public float spawnRateDec;


    
    private EnemySpawner enemySpawner;
	// Use this for initialization
	void Start () {
        enemySpawner = GameObject.Find("scripts").GetComponent<EnemySpawner>();
	}
	
	// Update is called once per frame
	void Update () {
       

        




    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "point")
        // if (col.gameObject.tag == "Player" || col.gameObject.tag == "enemy")
        {
            GameObject mob = col.gameObject.transform.parent.gameObject;
            if (mob.tag == "enemy")
            {
                if (mob.GetComponent<Skeleton>().dead == false)
                {
                    mob.GetComponent<Skeleton>().onHole = gameObject;
                    return;
                }
                else
                {
                    mob.GetComponent<Skeleton>().deadead = true;
                }


            }


            FallIn(mob);
           


        }
    }
    public void FallIn(GameObject mob) {

        mob.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (mob.tag == "Player")
        {
            Destroy(mob.GetComponent<Movement>());


        }
        Destroy(mob.GetComponent<BoxCollider2D>());
        mob.transform.position = transform.position;

        StartCoroutine(Die(mob));

    }
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "point")
        // if (col.gameObject.tag == "Player" || col.gameObject.tag == "enemy")
        {
            GameObject mob = col.gameObject.transform.parent.gameObject;
            if (mob.tag == "enemy")
            {
                if (mob.GetComponent<Skeleton>().dead == false)
                {

                    mob.GetComponent<Skeleton>().onHole = null;


                }
            }
            else { mob.transform.Find("bow").GetComponent<ShootArrows>().enabled = false; }
        }
    }

    IEnumerator Die(GameObject dead)
    {
        Destroy(dead.GetComponent<Rigidbody2D>());

        for (int i = 0; i < 40; i++)
        {
            dead.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1-i*0.05f);
;            if (dead.transform.localScale.x <= 0.5f)
            {
                break;

            }
            dead.transform.localScale -= new Vector3(0.3f, 0.3f, 0);
            dead.transform.position -= new Vector3(0, 0.05f, 0);
            yield return new WaitForSeconds(0.2f);
        }
        if (dead.tag == "Player")
        {
            dead.GetComponent<Archer>().TakeDamage(1000);

        }
        if (dead.tag == "enemy")
        {
            enemySpawner.spawnRate -= spawnRateDec;
            dead.GetComponent<Skeleton>().ProperDead();

        }





    }
    

}
    
