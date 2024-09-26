using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour
{
    public Canvas canvas;
    bool shmove = false;

    public void MoveAround(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

        if (pointerData.position.y < 70)
        {
            shmove = false;
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out position);
            transform.position = canvas.transform.TransformPoint(position);

        }
        Debug.Log(pointerData.position.y);
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            shmove = true;
        }
    }
    private void FixedUpdate()
    {
        if (shmove == true)
        {
            Shmove();
        }
    }

    void Shmove()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, new Vector2(-18, -240), 1*Time.deltaTime);
    }

}
