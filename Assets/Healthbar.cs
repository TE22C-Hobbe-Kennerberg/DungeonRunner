using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private float maxHealth;
    private Slider slider;
    void Start()
    {
        Slider slider = GetComponent<Slider>();
        maxHealth = transform.parent.GetComponent<Health>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float health = transform.parent.GetComponent<Health>().health;
        slider.value = health / maxHealth;
    }
}
