using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health { get; private set; }

    public void Damage(float amount)
    {
        health -= amount;
    }
    public void Heal(float amount)
    {
        health += amount;
    }
}
