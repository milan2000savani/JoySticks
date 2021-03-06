using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{

    public RectTransform Pad;
    public Transform Player;

    public Vector3 move;
    public float moveSpeed;
public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)Pad.position, Pad.rect.width * .5f);

        move = new Vector3(transform.localPosition.x, 0, transform.localPosition.y).normalized;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pad.transform.position = Input.mousePosition;

    }


    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        move = Vector3.zero;
    }

    IEnumerator PlayerMove()
    {
        while(true)
        {

            Player.Translate(move.normalized * moveSpeed * Time.deltaTime, Space.World);

            if(move != Vector3.zero)
            {
                Player.rotation = Quaternion.Slerp(Player.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            }

            yield return null;
        }
    }
}
