using UnityEngine;
using System.Collections;

public class CurvedMovementEngine : MonoBehaviour
{
    [SerializeField] float dodge;
    [SerializeField] float smoothing;
    [SerializeField] float tilt;
    [SerializeField] Vector2 startWait;
    [SerializeField] Vector2 maneuverTime;
    [SerializeField] Vector2 maneuverWait;

    private float currentSpeed;
    private float traget;
    private Rigidbody2D rdb2D;
    private Vector2 WindowPoint;

    void Start()
    {
        rdb2D = GetComponent<Rigidbody2D>();
        currentSpeed = rdb2D.velocity.y;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            traget = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            traget = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        EvasiveManeuver();
    }

    private void EvasiveManeuver()
    {
        WindowPoint = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
        float newСurvedPos = Mathf.MoveTowards(rdb2D.velocity.x, traget, Time.deltaTime * smoothing);
        rdb2D.velocity = new Vector3(newСurvedPos, currentSpeed);
        rdb2D.position = new Vector3
        (
            Mathf.Clamp(rdb2D.position.x, WindowPoint.x, WindowPoint.y),
            rdb2D.position.y
        );
    }    
}