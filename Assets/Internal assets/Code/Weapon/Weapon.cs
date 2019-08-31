using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Transform[] bulletSpawn;
    [SerializeField] protected Bullet bulletPrefab;
    [SerializeField] protected float fireRate;
    protected bool isEnemyWeapon;


    abstract protected bool isEnemy();
    abstract protected void Fire();

    protected  void SpawnBullet()
    {
        foreach (var item in bulletSpawn)
        {
            Bullet bullet = Instantiate(bulletPrefab, item.position, item.rotation);
            bullet.Init(isEnemy());
        }
    }
}
