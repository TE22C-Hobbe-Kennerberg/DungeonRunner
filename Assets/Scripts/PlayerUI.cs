using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Weapon playerWeaponScript;
    private EnemySpawner enemySpawner;
    [SerializeField] private GameObject levelUI;

    bool waitForUpgrade;
    bool selectedUpgrade;

    private void Start()
    {
        playerWeaponScript = GameObject.Find("Player").GetComponentInChildren<Weapon>();
        enemySpawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();   
        HideLevelUI();
    }

    private void Update()
    {
        if (waitForUpgrade)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerWeaponScript.LevelDamage();
                selectedUpgrade = true;

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerWeaponScript.LevelProjectileCount();
                selectedUpgrade = true;
            }

            if (selectedUpgrade)
            {
                waitForUpgrade = false;
                HideLevelUI();
                enemySpawner.NextWave();
            }
        }
    }

    public void SelectUpgrade()
    {
        selectedUpgrade = false;
        waitForUpgrade = true;
        ShowLevelUI();

    }

    public void ShowLevelUI()
    {
        levelUI.SetActive(true);
    }

    public void HideLevelUI()
    {
        levelUI.SetActive(false);
    }
    
}
