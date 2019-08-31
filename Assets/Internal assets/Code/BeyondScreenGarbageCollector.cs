using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeyondScreenGarbageCollector : MonoBehaviour
{
    private float offset = 100f;
    void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (gameObject.transform.position.y < min.y + offset
            || gameObject.transform.position.x < min.x + offset
            || gameObject.transform.position.y > max.y + offset
            || gameObject.transform.position.x > max.x + offset)
        {
            Destroy(gameObject);
        }
    }
}
