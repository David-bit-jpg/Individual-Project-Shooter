using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWeapon : Weapon
{
    [SerializeField] private Projectile projectilePrefab;

    public override void UseWeapon()
    {
        PlayShootAnimation();

        if (gameObject.CompareTag("ShotGun"))
        {
            ShootShotgunStyle();
        }
        else if (gameObject.CompareTag("LazerGun"))
        {
            ShootLazergunStyle();
        }
        else
        {
            ShootSingleProjectile();
        }
    }

    private void ShootSingleProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab);
        projectile.transform.position = shootPos.position;
        projectile.Direction = shootPos.right;
        float randomSpread = Random.Range(itemWeapon.MinSpread, itemWeapon.MaxSpread);
        projectile.transform.rotation = Quaternion.Euler(randomSpread * Vector3.forward);
    }

    private void ShootShotgunStyle()
    {
        const int numberOfBullets = 10;
        for (int i = 0; i < numberOfBullets; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab);
            projectile.transform.position = shootPos.position;
            projectile.Direction = shootPos.right;
            float randomSpread = Random.Range(itemWeapon.MinSpread, itemWeapon.MaxSpread);
            projectile.transform.rotation = Quaternion.Euler(randomSpread * Vector3.forward);
        }
    }
    private void ShootLazergunStyle()
    {
        Projectile projectile = Instantiate(projectilePrefab);
        projectile.transform.position = shootPos.position;
        projectile.Direction = shootPos.right;
        float randomSpread = Random.Range(itemWeapon.MinSpread, itemWeapon.MaxSpread);
        projectile.transform.rotation = Quaternion.Euler(randomSpread * Vector3.forward);
    }



    public override void DestroyWeapon()
    {
        Destroy(gameObject);
    }
}
