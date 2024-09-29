using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class drag : MonoBehaviour
{
    public Canvas canvas;
    public bool shmove = false;

    Vector2 pos1 = new Vector2(-389.6421f, 113.2f);
    Vector2 pos2 = new Vector2(268, 113.2f);
    Vector2 pos3 = new Vector2(-389.6421f, -162.47f);
    Vector2 pos4 = new Vector2(268, -162.47f);
    public gameFunctions gamer;
    public bool imIn1;
    public bool imIn2;
    public bool imIn3;
    public bool imIn4;

    Vector2 startingPos;

    public void Start()
    {
        startingPos = transform.localPosition;
    }
    public void MoveAround(BaseEventData data)
    {
        if (gamer.started == false && imIn1 == false && imIn2 == false && imIn3 == false && imIn4 == false)
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
        }
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (((Mathf.Abs(transform.localPosition.x - pos1.x) > 0.1f) || (Mathf.Abs(transform.localPosition.y - pos1.y) > 0.1f)) &&
                ((Mathf.Abs(transform.localPosition.x - pos2.x) > 0.1f) || (Mathf.Abs(transform.localPosition.y - pos2.y) > 0.1f)) &&
                ((Mathf.Abs(transform.localPosition.x - pos3.x) > 0.1f) || (Mathf.Abs(transform.localPosition.y - pos3.y) > 0.1f)) &&
                ((Mathf.Abs(transform.localPosition.x - pos4.x) > 0.1f) || (Mathf.Abs(transform.localPosition.y - pos4.y) > 0.1f)))
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
            if (shmove == true && (Mathf.Abs(transform.localPosition.x - pos2.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos2.y) < 35))
            {
                for (int i = 0; i < gamer.options.Length; i++)
                {
                    if (gamer.options[i] != this.gameObject && gamer.options[i].GetComponent<drag>().imIn2 == true)
                        gamer.options[i].transform.localPosition = gamer.options[i].transform.localPosition + new Vector3(0, -50, 0);
                    gamer.options[i].GetComponent<drag>().shmove = true;
                    gamer.options[i].GetComponent<drag>().imIn2 = false;
                }
                gamer.twoIs = this.gameObject.tag;
                imIn2 = true;
            }
            if (shmove == true && (Mathf.Abs(transform.localPosition.x - pos3.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos3.y) < 35))
            {
                for (int i = 0; i < gamer.options.Length; i++)
                {
                    if (gamer.options[i] != this.gameObject && gamer.options[i].GetComponent<drag>().imIn3 == true)
                        gamer.options[i].transform.localPosition = gamer.options[i].transform.localPosition + new Vector3(0, -50, 0);
                    gamer.options[i].GetComponent<drag>().shmove = true;
                    gamer.options[i].GetComponent<drag>().imIn3 = false;
                }
                gamer.thrIs = this.gameObject.tag;
                imIn3 = true;
            }
            if (shmove == true && (Mathf.Abs(transform.localPosition.x - pos4.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos4.y) < 35))
            {
                for (int i = 0; i < gamer.options.Length; i++)
                {
                    if (gamer.options[i] != this.gameObject && gamer.options[i].GetComponent<drag>().imIn4 == true)
                        gamer.options[i].transform.localPosition = gamer.options[i].transform.localPosition + new Vector3(0, -50, 0);
                    gamer.options[i].GetComponent<drag>().shmove = true;
                    gamer.options[i].GetComponent<drag>().imIn4 = false;
                }
                gamer.fouIs = this.gameObject.tag;
                imIn4 = true;
            }
        }
        if (shmove == true)
        {
            Shmove();
            if ((imIn1 == true && (Mathf.Abs(transform.localPosition.x - pos1.x) < 0.05f) || (Mathf.Abs(transform.localPosition.y - pos1.y) < 0.1f)) ||
                (imIn2 == true && (Mathf.Abs(transform.localPosition.x - pos2.x) < 0.05f) || (Mathf.Abs(transform.localPosition.y - pos2.y) < 0.1f)) ||
                (imIn3 == true && (Mathf.Abs(transform.localPosition.x - pos3.x) < 0.05f) || (Mathf.Abs(transform.localPosition.y - pos3.y) < 0.1f)) ||
                (imIn4 == true && (Mathf.Abs(transform.localPosition.x - pos4.x) < 0.05f) || (Mathf.Abs(transform.localPosition.y - pos4.y) < 0.1f)))
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
        else if (imIn2 == true && (Mathf.Abs(transform.localPosition.x - pos2.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos2.y) < 35))
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos2, 4 * Time.deltaTime);
        else if (imIn3 == true && (Mathf.Abs(transform.localPosition.x - pos3.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos3.y) < 35))
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos3, 4 * Time.deltaTime);
        else if (imIn4 == true && (Mathf.Abs(transform.localPosition.x - pos4.x) < 100) && (Mathf.Abs(transform.localPosition.y - pos4.y) < 35))
            transform.localPosition = Vector2.Lerp(transform.localPosition, pos4, 4 * Time.deltaTime);
        else
            transform.localPosition = Vector2.Lerp(transform.localPosition, startingPos, 4 * Time.deltaTime);
    }

}
