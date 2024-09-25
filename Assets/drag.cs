using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour
{
    public Canvas canvas;
    public bool boo;

    public void MoveAround(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        if (pointerData.position.y < 70)
        {
            boo= true;
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out position);
            transform.position = canvas.transform.TransformPoint(position);

            boo = false;
        }
        Debug.Log(pointerData.position.y);
    }

    public void Update()
    {
        Debug.Log(boo);
    }

}
