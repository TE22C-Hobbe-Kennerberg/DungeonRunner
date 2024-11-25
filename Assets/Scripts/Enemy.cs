using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health healthScript;
    [SerializeField] public EnemyStats stats;
    

    void Start()
    {
        healthScript = GetComponent<Health>();
        healthScript.maxHealth = stats.startingHealth;
        healthScript.health = stats.startingHealth;

        transform.localScale = Vector3.one * stats.size;
    }

    void Update()
    {
        // Move towards player.
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 movement = playerPos - transform.position;
        movement = movement.normalized * stats.speed / 1000;
        transform.position += movement;

        if(healthScript.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Projectile(Clone)")
        {
            GameObject projectile = collision.gameObject;
            healthScript.Damage(projectile.GetComponent<Projectile>().damage);
        }

        if(collision.gameObject.name == "Player"){
            collision.gameObject.GetComponent<Health>().Damage(stats.damage);
        }
        
    }
}
