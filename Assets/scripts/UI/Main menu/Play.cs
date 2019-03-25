using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
    private bool ready=false;
    public  float speed;
    public float distance;

    private GameObject archer;
    private GameObject bow;
    private GameObject cam;
    // Use this for initialization
    void Start () {
        archer =GameObject.Find("archer");
        cam = GameObject.Find("Main Camera");
        bow = GameObject.Find("bow");
    }
	
	// Update is called once per frame
	void Update () {
        if (ready) {
            
            bow.GetComponent<ShootArrows>().enabled = false;
            archer.GetComponent<BoxCollider2D>().enabled = false;
            archer.GetComponent<Animator>().SetBool("walking", true);
            archer.transform.position=Vector3.MoveTowards(archer.transform.position, new Vector3(archer.transform.position.x, archer.transform.position.y + distance),(speed+0.7f)*Time.deltaTime);
            cam.transform.position=Vector3.MoveTowards(cam.transform.position, new Vector3(cam.transform.position.x, cam.transform.position.y + distance),speed*Time.deltaTime);
            if (cam.transform.position.y > distance) {
                SceneManager.LoadScene("scene1");
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "playerProjectile") {
            ready = true;
            


        }
    }
}
