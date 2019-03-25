using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootArrows : MonoBehaviour {
    public AudioSource source;
    public GameObject arrow;
    public float speed;
    public float fireRate;
    public int damage;
    public float range;
    public float force;
    private bool ready = true;
    public JoyStick joystick;
	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        
        if ((Input.GetMouseButton(0) && Application.platform != RuntimePlatform.Android) || (Input.GetMouseButton(0) && (Application.platform == RuntimePlatform.Android && SceneManager.GetActiveScene().name == "main menu"))) 
        {
           
            if (ready) {
               
                GameObject arrowObj = Instantiate(arrow, transform.position, transform.rotation);
                //Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                //Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
                //Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                worldPoint.z = transform.position.z;
                Vector3 dir = (transform.position - worldPoint).normalized;
               

                arrowObj.GetComponent<Rigidbody2D>().AddForce(-dir * speed);
                arrowObj.GetComponent<ArrowManager>().range = range;
                arrowObj.GetComponent<ArrowManager>().damage = damage;
                arrowObj.GetComponent<ArrowManager>().pos = transform.position;
                arrowObj.GetComponent<ArrowManager>().force = force;

                
                
                source.Play();


                StartCoroutine(WaitBetweenShots());

            }
            
            
        }
        if (Application.platform==RuntimePlatform.Android) {
            Debug.Log(joystick.GetComponent<JoyStick>().Horizontal());
            if(joystick.GetComponent<JoyStick>().Horizontal() != 0 || joystick.GetComponent<JoyStick>().Vertical() != 0){
                if (ready)
                {

                    GameObject arrowObj = Instantiate(arrow, transform.position, transform.rotation);
                    //Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    //Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
                    //Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
                    Vector3 worldPoint =  new Vector3(joystick.GetComponent<JoyStick>().Horizontal(), joystick.GetComponent<JoyStick>().Vertical());

                    worldPoint.z = transform.position.z;
                    Vector3 dir = ( - worldPoint).normalized;


                    arrowObj.GetComponent<Rigidbody2D>().AddForce(-dir * speed);
                    arrowObj.GetComponent<ArrowManager>().range = range;
                    arrowObj.GetComponent<ArrowManager>().damage = damage;
                    arrowObj.GetComponent<ArrowManager>().pos = transform.position;
                    arrowObj.GetComponent<ArrowManager>().force = force;



                    source.Play();


                    StartCoroutine(WaitBetweenShots());

                }
            }


        }
	}
    IEnumerator WaitBetweenShots()
    {

        ready = false;

        yield return new WaitForSeconds(1/fireRate);

        ready = true;



    }
}
