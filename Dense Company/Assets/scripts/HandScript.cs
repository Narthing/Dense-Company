using System.Collections;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public Vector2 mousepos;
    public GameObject hand;
    public RectTransform tablet; 

    Vector2 endPos = new Vector2(-586, -108);
    Vector2 endPos2 = new Vector2(-1350, -108);

    public bool isMoving = false;
    public bool equipped = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(RotateHand());
        }

        if (Input.GetMouseButtonDown(1) && !isMoving)
        {
            if (!equipped)
            {
                StartCoroutine(Slide());
            }
            else
            {
                StartCoroutine(Slideback());
            }
        }
    }

    IEnumerator RotateHand()
    {
        hand.transform.rotation = Quaternion.Euler(0, 0, 70); // rotate
        yield return new WaitForSeconds(0.1f);
        hand.transform.rotation = Quaternion.Euler(0, 0, 0); // reset
    }

    IEnumerator Slide()
    {
        isMoving = true;

        float duration = 0.3f;
        float time = 0f;

        // start from current ui position
        Vector2 start = tablet.anchoredPosition;

        while (time < duration)
        {
            float t = time / duration;

            // move ui properly
            tablet.anchoredPosition = Vector2.Lerp(start, endPos, t);

            time += Time.deltaTime;
            yield return null;
        }

        tablet.anchoredPosition = endPos;

        isMoving = false;
        equipped = true;
    }

    IEnumerator Slideback()
    {
        isMoving = true;

        float duration = 0.3f;
        float time = 0f;

        Vector2 start = tablet.anchoredPosition;

        while (time < duration)
        {
            float t = time / duration;

            tablet.anchoredPosition = Vector2.Lerp(start, endPos2, t);

            time += Time.deltaTime;
            yield return null;
        }

        tablet.anchoredPosition = endPos2;

        isMoving = false;
        equipped = false;
    }
}