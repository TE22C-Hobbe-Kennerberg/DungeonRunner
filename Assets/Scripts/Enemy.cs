using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Health healthScript;
    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    void Update()
    {
        
    }
}
