using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponStats stats;
    [SerializeField] private GameObject projectilePrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.transform);
            projectile.GetComponent<Rigidbody2D>().velocity = transform.forward * stats.projectileSpeed;
        }
    }
}
