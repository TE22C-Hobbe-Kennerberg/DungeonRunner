using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private RangedWeaponStats stats;
    [SerializeField] private GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for(int i = 0; i < stats.bulletCount; i++)
            {  
                // Calculates rotation based on spread.
                float spread = stats.spread;
                float rotation = Random.Range((int)(-spread / 2), (int)(spread / 2));
                Vector3 rotationVector = transform.eulerAngles + new Vector3(0, 0, rotation);

                // Spawns projectile with correct rotation.
                GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(rotationVector));
                // Removes parent
                projectile.transform.parent = null;
                // Sets range
                projectile.GetComponent<Projectile>().stats = stats;
            }



        }
    }
}
