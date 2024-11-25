using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private float maxHealth;
    [SerializeField] private Slider slider;

    // Update is called once per frame
    void Update()
    {
        maxHealth = transform.parent.GetComponent<Health>().maxHealth;
        float health = transform.parent.GetComponent<Health>().health;
        slider.value = health / maxHealth;
    }
}
