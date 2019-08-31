using UnityEngine;
using UnityEditor;
using System;

public class ShipHealf : Health
{
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        var bonus = collision.gameObject.GetComponent<Bonus>();
        if (bonus != null)
        {
            RestoreHealth(bonus.RestoreHealth);
            Destroy(bonus.gameObject);
        }
            
    }

    protected override bool isEnemy()
    {
        return false;
    }

    private void RestoreHealth(float health)
    {
        if (this.health + health >= maxHealth)
            this.health = maxHealth;
        else
            this.health += health;
        InGameUIManager.Instance.SetHealthSliderValue(this.health / maxHealth);
    }
    protected override void Die()
    {
        base.Die();
        InGameUIManager.Instance.GameOver();
    }

    protected override void TakeDamage(float damage)
    {
       
        base.TakeDamage(damage);
        InGameUIManager.Instance.SetHealthSliderValue(health / maxHealth);
    }
}