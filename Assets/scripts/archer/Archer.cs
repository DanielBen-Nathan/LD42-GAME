using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Archer : MonoBehaviour {
    public int maxHealth;
    public int health;

    public bool dead = false;
   // public Slider bar2;
    public HealthBarScript bar;
    // Use this for initialization
    void Start() {
        health = maxHealth;
        bar = GameObject.Find("HealthBar").GetComponent<HealthBarScript>();
        // Slider bar2 = GameObject.Find("canvas").GetComponent<Slider>();
        //bar2.value=30;
        //bar = bar2.GetComponent<HealthBarScript>();
        bar.SetMaxValue(maxHealth);
        bar.SetValue(health);
    }

    // Update is called once per frame
    void Update() {

    }


    public void TakeDamage(int dmg) {
        health = health - dmg;
        bar.SetValue(health);
        if (health <= 0 &&!dead) {
            if (dmg == 1000)
            {
                GetComponent<SpriteRenderer>().enabled = false;
              

            }
            else {
                transform.Rotate(0, 0, 90);
                GetComponent<Movement>().enabled = false;
                transform.Find("bow").GetComponent<BowMovement>().enabled = false;
                transform.Find("bow").GetComponent<ShootArrows>().enabled = false;
                transform.Find("shadow").GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Animator>().SetBool("walking", false);

            }
           
            dead = true;
            UserInterface userInterface = GameObject.Find("Canvas").GetComponent<UserInterface>();
            userInterface.GameOver();


        }
        if (health >= maxHealth)
        {
            dmg = -(maxHealth - (health + dmg));
            health = maxHealth;

        }
        if (dmg > 0) {
            GetComponent<Flash>().FlashOnDmg();


        }



    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemyProjectile") {
            TakeDamage(col.gameObject.GetComponent<ArrowManager>().damage);

        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "medkit"&&health!=maxHealth) {
            TakeDamage((int)col.gameObject.GetComponent<Pickup>().effectiveness);
            Destroy(col.gameObject);

        }
        if (col.gameObject.tag == "dmgkit" )
        {
            transform.Find("bow").GetComponent<ShootArrows>().fireRate += col.gameObject.GetComponent<Pickup>().effectiveness;
            Destroy(col.gameObject);

        }
    }
    
}
