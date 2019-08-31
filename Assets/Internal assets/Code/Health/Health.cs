using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float health;
    abstract protected bool isEnemy();
    private void Start()
    {
        health = maxHealth;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    { 
        var bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null && bullet.IsEnemyBullet != isEnemy())
            TakeDamage(bullet.Damage);
        if (isEnemy() && collision.gameObject.tag == "Ship" || !isEnemy() && collision.gameObject.tag == "Enemy")
            Die();
    }

    protected virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

}
