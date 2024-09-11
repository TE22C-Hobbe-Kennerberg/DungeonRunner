using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon stat", menuName = "Weapon/Ranged Weapon stats")]
public class RangedWeaponStats : WeaponStats
{
    public float projectileSpeed;
    public int maxAmmo;
    public int bulletCount;
}
