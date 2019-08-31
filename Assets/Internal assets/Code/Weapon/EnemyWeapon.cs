using UnityEngine;
using UnityEditor;

public class EnemyWeapon : Weapon
{
    protected void Start()
    {
        Fire();
    }
    protected override void Fire()
    {
        foreach (var item in bulletSpawn)
        {
            InvokeRepeating("SpawnBullet", 0, fireRate);
        }
    }

    protected override bool isEnemy()
    {
        return true;
    }
}