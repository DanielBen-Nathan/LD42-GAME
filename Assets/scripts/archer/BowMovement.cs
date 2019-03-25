using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowMovement : MonoBehaviour {
    public JoyStick joystick;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (Application.platform != RuntimePlatform.Android ||(Application.platform == RuntimePlatform.Android && SceneManager.GetActiveScene().name=="main menu")) {

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 vectorToTarget = -worldPoint + transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);


        }
        if (Application.platform == RuntimePlatform.Android)
        {

            Vector3 worldPoint = new Vector3(joystick.GetComponent<JoyStick>().Horizontal(), joystick.GetComponent<JoyStick>().Vertical(),0);

            Vector3 vectorToTarget = -worldPoint;// + transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);


        }



    }
}
