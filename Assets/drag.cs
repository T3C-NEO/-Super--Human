using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour
{
    public Canvas canvas;
    public bool shmove = false;

    Vector2 pos1 = new Vector2(-389.6421f, 113.2f);
    public gameFunctions gamer;
    public bool imIn1;

    Vector2 startingPos;

    public void Start()
    {
        startingPos = transform.localPosition;
    }
    public void MoveAround(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;

            shmove = false;
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)canvas.transform,
                pointerData.position,
                canvas.worldCamera,
                out position);
            transform.position = canvas.transform.TransformPoint(position);

        Debug.Log(pointerData.position.y);
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if ((Mathf.Abs(transform.localPosition.x - pos1.x) > 0.1f) || (Mathf.Abs(transform.localPosition.y - pos1.y) > 0.1f))
                shmove = true;
          
            if (shmove == true && (Mathf.Abs(transform.localPosition.x - pos1.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos1.y) < 35))
            {
                for (int i = 0; i < gamer.options.Length; i++)
                {
                    if (gamer.options[i] != this.gameObject && gamer.options[i].GetComponent<drag>().imIn1 == true)
                        gamer.options[i].transform.localPosition = gamer.options[i].transform.localPosition + new Vector3(0, -50, 0);
                        gamer.options[i].GetComponent<drag>().shmove = true;
                        gamer.options[i].GetComponent<drag>().imIn1 = false;
                }
                gamer.oneIs = this.gameObject.tag;
                imIn1 = true;
            }
        }
        if (shmove == true)
        {
            Shmove();
            if (imIn1 == true && (Mathf.Abs(transform.localPosition.x - pos1.x) < 0.1f) || (Mathf.Abs(transform.localPosition.y - pos1.y) < 0.1f))
                shmove = false;
        }
    }
    private void FixedUpdate()
    {
        
    }

    void Shmove()
    {
        if (imIn1 == true && (Mathf.Abs(transform.localPosition.x - pos1.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos1.y) < 35))
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos1, 4*Time.deltaTime);
        else
            transform.localPosition = Vector2.Lerp(transform.localPosition, startingPos, 4 * Time.deltaTime);
    }

}
