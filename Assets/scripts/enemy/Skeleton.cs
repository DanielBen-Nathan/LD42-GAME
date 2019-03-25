using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {
    public int maxHealth;
    public int health;
    public int scoreOnDeath;
    public int scoreOnProperDeath;



    public bool dead = false;
    public bool deadead = false;
    public bool spawned = false;
    public float enlargeOnDeath;
    public GameObject onHole = null;

    private Score score;
    // Use this for initialization
    void Start () {
        health = maxHealth;
        score = GameObject.Find("Canvas").GetComponent<Score>();
        GetComponent<Rigidbody2D>().mass = GetComponent<Rigidbody2D>().mass * 1000;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDamage(int dmg)
    {
        if (!dead &&spawned) {
            health = health - dmg;
            if (dmg > 0)
            {
                GetComponent<Flash>().FlashOnDmg();


            }
            if (health <= 0)
            {
                Destroy(transform.GetChild(1).gameObject);
                Destroy(transform.GetChild(0).gameObject);
                //Destroy(GetComponent<Skeleton>());
                Destroy(GetComponent<EnemyMovement>());
                transform.Rotate(0, 0, 90);
                transform.localScale += new Vector3(transform.localScale.x / enlargeOnDeath, transform.localScale.y / enlargeOnDeath, 0);
                dead = true;
                score.AddScore(scoreOnDeath);
                if (onHole) {
                    onHole.GetComponent<Hole>().FallIn(gameObject);


                }
            }
            


        }
        



    }
    public void ProperDead() {
        score.AddScore(scoreOnProperDeath);
        Destroy(gameObject);


    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "playerProjectile" &&spawned)
        {
            ArrowManager arrowManager = col.gameObject.GetComponent<ArrowManager>();
            TakeDamage(arrowManager.damage);
            Vector2 dir = (col.gameObject.transform.position - arrowManager.pos).normalized;

            if (dead)
            {
                //Vector2 dir = (col.gameObject.transform.position- arrowManager.pos).normalized;
                if (deadead == false)
                {
                    GetComponent<Rigidbody2D>().AddForce(dir * arrowManager.force);
                }



            }
            else {
                GetComponent<Rigidbody2D>().AddForce(dir * arrowManager.force*2);
            }


            Destroy(col.gameObject);
           

        }
    }
}
