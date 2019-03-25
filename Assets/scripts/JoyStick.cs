using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{

    private Image bgImage;
    private Image StickImage;
    private Vector3 inputVector;
    public bool isOver = false;
    // Use this for initialization
    void Start () {
        bgImage=GetComponent<Image>();
        StickImage=transform.GetChild(0).GetComponent<Image>();
        if (Application.platform != RuntimePlatform.Android) {
            gameObject.SetActive(false);

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void OnPointerDown(PointerEventData ped) {
        OnDrag(ped);

    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        StickImage.rectTransform.anchoredPosition = Vector3.zero;

    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform,ped.position,ped.pressEventCamera,out pos)) {
            pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 5f , 0, pos.y * 5f );
            if (inputVector.magnitude > 1.0f) {
                inputVector = inputVector.normalized;

            }
            StickImage.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImage.rectTransform.sizeDelta.x / 3), inputVector.z * bgImage.rectTransform.sizeDelta.y / 3);

        }

    }
    public float Horizontal()
    {
        if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        else {

            return Input.GetAxis("Horizontal");
        }


    }
    public float Vertical()
    {
        if (inputVector.z != 0)
        {
            return inputVector.z;
        }
        else
        {

            return Input.GetAxis("Vertical");
        }

    }
  

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse enter");
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse exit");
        isOver = false;
    }
}
