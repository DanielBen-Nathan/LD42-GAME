using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour {
    public float speed;

    public bool walking = false;
    private Animator anim;
    // Use this for initialization
    private bool disableLeft = false;
    private bool disableRight = false;
    private bool disableDown = false;
    private bool disableUp = false;
    public JoyStick joystick;
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        walking = false;



        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (Input.GetKey("w") && !disableUp && Application.platform != RuntimePlatform.Android)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 65f * speed * Time.deltaTime);
            walking = true;
        }
     
        if (Input.GetKey("s") && !disableDown && Application.platform != RuntimePlatform.Android)
        {
            //transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, - 65f * speed * Time.deltaTime);
            walking = true;
        }
       
        if (Input.GetKey("d") && !disableRight && Application.platform != RuntimePlatform.Android)
        {
            //transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(65f * speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
            walking = true;
        }
        if (Input.GetKey("a") && !disableLeft && Application.platform != RuntimePlatform.Android)
        {
            //transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-65f * speed * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y);
            walking = true;
        }



        
        if(Application.platform == RuntimePlatform.Android) {

            //transform.position = new Vector2(transform.position.x + joystick.GetComponent<JoyStick>().Horizontal() * 1.2f*speed * Time.deltaTime, transform.position.y);
            //transform.position = new Vector2(transform.position.x, transform.position.y + joystick.GetComponent<JoyStick>().Vertical() * 1.2f*speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().velocity =  new Vector2( joystick.GetComponent<JoyStick>().Horizontal() * 65f * speed * Time.deltaTime,  joystick.GetComponent<JoyStick>().Vertical() * 65f * speed * Time.deltaTime);
            Debug.Log(joystick.GetComponent<JoyStick>().Horizontal());
            if (joystick.GetComponent<JoyStick>().Horizontal() != 0 || joystick.GetComponent<JoyStick>().Vertical() != 0)
            {
                walking = true;
            }
        }
       


       
        

        transform.rotation = Quaternion.identity;


        if (walking)
        {
            anim.SetBool("walking", true);

        }
        else {
            anim.SetBool("walking", false);

        }

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall" && Application.platform != RuntimePlatform.Android) {
            if (col.gameObject.name == "LeftWallCol") {

                disableLeft = true;

            }
            if (col.gameObject.name == "RightWallCol")
            {

                disableRight = true;

            }
            if (col.gameObject.name == "FrontWall")
            {

                disableDown = true;

            }
            if (col.gameObject.name == "BackWall")
            {

                disableUp = true;

            }

        }

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            if (col.gameObject.name == "LeftWallCol")
            {

                disableLeft = false;

            }
            if (col.gameObject.name == "RightWallCol")
            {

                disableRight = false;

            }
            if (col.gameObject.name == "FrontWall")
            {

                disableDown = false;

            }
            if (col.gameObject.name == "BackWall")
            {

                disableUp = false;

            }

        }

    }
}
