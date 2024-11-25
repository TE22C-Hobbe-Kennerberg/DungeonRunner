using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Update()
    {
        Health healthScript = GetComponent<Health>();
        if(healthScript.health <= 0)
        {
            GameObject.Find("Scene Controller").GetComponent<SceneController>().LoadGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            float damage = collision.gameObject.GetComponent<Enemy>().stats.damage;
            GetComponent<Health>().Damage(damage);
        }
    }
}
