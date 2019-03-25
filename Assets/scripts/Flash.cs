using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour {

    public Color color;
    public float time;
    public void FlashOnDmg() {

        StartCoroutine(TimeWait());

    }
	
    IEnumerator TimeWait()
    {


        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().color = new Color(1F, 1F, 1F, 1F);




    }
}
