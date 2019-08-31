using UnityEngine;
using UnityEditor;

public class ShipWeapon : Weapon
{
    protected float nextFire;
    private void Start()
    {
        InputManager.Instance.OnFire += Fire;
    }

    protected override void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SpawnBullet();
        }
    }
    private void OnDestroy()
    {
        InputManager.Instance.OnFire -= Fire;
    }
    protected override bool isEnemy()
    {
        return false;
    }
}