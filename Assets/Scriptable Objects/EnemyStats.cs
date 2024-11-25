using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemyStats : ScriptableObject
{
    public float startingHealth;
    public float speed;
    public float damage;
    public float size;
}
