using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEngine : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        ShipMoving();
    }

    private void ShipMoving()
    {
        float moveHorizontal = InputManager.Instance.Horizontal;
        
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rigidbody2d.velocity = movement * speed;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        rigidbody2d.position = new Vector2
        (
            Mathf.Clamp(rigidbody2d.position.x, min.x, max.x),
            Mathf.Clamp(rigidbody2d.position.y, min.y, max.y)
        );
    }
}
