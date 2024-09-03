using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Stats", menuName = "Enemy/Enemy Data")]
public class EnemyStats : ScriptableObject
{
    public float startingHealth;
    public float speed;
}
