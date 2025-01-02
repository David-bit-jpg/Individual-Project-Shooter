using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponType
{
    Melee,
    Gun
}
public enum WeaponRarity
{
    Common,
    Rare,
    Epic,
    Legendary
}
[CreateAssetMenu(menuName = "Item/Weapon")]
public class ItemWeapon : ItemData
{
    [Header("Data")]
    public WeaponType WeaponType;
    public WeaponRarity WeaponRarity;
    [Header("Settings")]
    public float Damage;
    public float RequiredEnergy;
    public float ShotSpeed;
    public float MinSpread;
    public float MaxSpread;

    public float ShootDistance;
}
