using UnityEngine;
using System.Collections;

public class ObjectEngine : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = transform.up * speed;
    }
}
