using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloatingJoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public GameObject joyStick;
    public GameObject joyStickBG;
    public Vector2 joyStickVec;
    public Vector3 move;
    private Vector2 joyStickTouchPos;
    private Vector2 joyStickOriginalPos;
    private float joyStickRadius;


    private void Start()
    {
        joyStickOriginalPos = joyStickBG.transform.position;
        joyStickRadius = joyStickBG.GetComponent<RectTransform>().sizeDelta.y-joyStick.GetComponent<RectTransform>().sizeDelta.y/2;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dragPos = eventData.position;
        
        joyStickVec = (dragPos - joyStickTouchPos).normalized;
        move = new Vector3(joyStickVec.x, 0, joyStickVec.y);
        float joyStickDist = Vector2.Distance(dragPos, joyStickTouchPos);

        if(joyStickDist < joyStickRadius)
        {
            joyStick.transform.position = joyStickTouchPos + joyStickVec * joyStickDist;
        }
        else
        {
            joyStick.transform.position = joyStickTouchPos + joyStickVec * joyStickRadius; 
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        joyStick.transform.position = Input.mousePosition;
        joyStickBG.transform.position = Input.mousePosition;
        joyStickTouchPos = Input.mousePosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joyStickVec = Vector2.zero;
        move = Vector3.zero;
        joyStickBG.transform.position = joyStickOriginalPos;
        joyStick.transform.position = joyStickBG.transform.position;
    }
}
