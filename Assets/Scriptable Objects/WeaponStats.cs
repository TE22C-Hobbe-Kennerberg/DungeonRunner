using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon stat", menuName = "Weapon/Weapon stats")]

public class WeaponStats : ScriptableObject
{
    public float damage;
    public float cooldown;
    public float radius;
    public float projectileSpeed;
}
