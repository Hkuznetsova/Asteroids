using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;

    public float Damage { get { return damage; } }
    public bool IsEnemyBullet { get; private set; }

    public void Init(bool IsEnemyBullet)
    {
        this.IsEnemyBullet = IsEnemyBullet;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsEnemyBullet && collision.tag == "Enemy")
        {
            return;
        }
        if (!IsEnemyBullet && collision.tag == "Ship")
        {
            return;
        }
        if (collision.GetComponent<Bullet>())
        {
            return;
        }
        if (collision.tag == "Bonus")
        {
            return;
        }
        Destroy(gameObject);
    }
}
