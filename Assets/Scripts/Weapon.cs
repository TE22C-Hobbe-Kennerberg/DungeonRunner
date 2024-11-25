using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject barrel;

    [Header("Stats")]
    [SerializeField] private float damage = 5;
    [SerializeField] private float range = 15;
    [SerializeField] private float spread = 15;
    [SerializeField] private float projectileSpeed = 10;
    [SerializeField] private int projectileCount = 1;
    [Space(25)]
    [SerializeField] private float damagePerLevel = 1;



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
                GameObject projectile = Instantiate(projectilePrefab, barrel.transform.position, Quaternion.Euler(rotationVector));

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

    public void LevelDamage()
    {
        damage += damagePerLevel;
    }
    public void LevelProjectileCount()
    {
        projectileCount++;
    }
}
