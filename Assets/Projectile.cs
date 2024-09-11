using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [NonSerialized] public float range;
    private Vector3 startLocation;
    void Start()
    {
        startLocation = transform.position;
    }

    void Update()
    {
        if(Vector3.Distance(startLocation, transform.position) > range)
        {
            Destroy(gameObject);
        }
    }
}
