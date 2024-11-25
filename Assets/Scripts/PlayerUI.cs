using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Weapon playerWeaponScript;
    private EnemySpawner enemySpawner;
    [SerializeField] private GameObject levelUI;

    private void Start()
    {
        playerWeaponScript = GameObject.Find("Player").GetComponentInChildren<Weapon>();
        enemySpawner = GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>();   
        HideLevelUI();
    }

    public void SelectUpgrade(int upgrade)
    {
        Debug.Log("Button pressed!");
        // 0. Damage, 1. Projectile count.
        switch (upgrade)
        {
            case 0:
                playerWeaponScript.LevelDamage();
                break;
            case 1:
                playerWeaponScript.LevelProjectileCount();
                break;
        }
        HideLevelUI();
        enemySpawner.NextWave();
    }

    public void ShowLevelUI()
    {
        Debug.Log("here");
        levelUI.SetActive(true);
    }

    public void HideLevelUI()
    {
        levelUI.SetActive(false);
    }
    
}
