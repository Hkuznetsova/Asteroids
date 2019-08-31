using UnityEngine;
using UnityEditor;

public class EnemyHealth : Health
{
    protected override bool isEnemy()
    {
        return true;
    }
    protected override void Die()
    {
        InGameUIManager.Instance.SetScoreValue((int)maxHealth);
        base.Die();
    }
}