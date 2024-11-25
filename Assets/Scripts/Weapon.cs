using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [Header("Stats")]
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float cooldown;
    [SerializeField] private float spread;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private int maxAmmo;
    [SerializeField] private int projectileCount;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < projectileCount; i++)
            {  
                // Calculates rotation based on spread.
                float rotation = Random.Range((int)(-spread / 2), (int)(spread / 2));
                Vector3 rotationVector = transform.eulerAngles + new Vector3(0, 0, rotation);

                // Spawns projectile with correct rotation.
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(rotationVector));

                // Removes parent
                projectile.transform.parent = null;

                // Sets stats.
                Projectile projectileScript = projectile.GetComponent<Projectile>();
                projectileScript.damage = damage;
                projectileScript.speed = projectileSpeed;
                projectileScript.range = range;
            }
        }
    }
}
