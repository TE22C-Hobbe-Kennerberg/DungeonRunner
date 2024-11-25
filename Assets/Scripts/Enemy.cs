using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health healthScript;
    [SerializeField] public EnemyStats stats;
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        healthScript = GetComponent<Health>();
        healthScript.maxHealth = stats.startingHealth;
        healthScript.health = stats.startingHealth;

        transform.localScale = Vector3.one * stats.size;
    }

    void Update()
    {
        Movement();
        CheckHealth();
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

    private void Movement()
    {
        // Move towards player.
        Vector3 playerPos = GameObject.Find("Player").transform.position;
        Vector3 movement = playerPos - transform.position;
        movement = movement.normalized * stats.speed;
        rb.velocity = movement;
    }

    private void CheckHealth()
    {
        if (healthScript.health <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>().KilledEnemy();
        }
    }
}
