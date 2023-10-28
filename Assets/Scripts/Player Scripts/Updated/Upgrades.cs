using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    /* After choosing an upgrade (pressing the button) go back to GamePlay State
     * Remove the levelup screen
     * Then change timescale back to 1 (from 0/paused) */
    private void LevelUpStateHandler()
    {
        GameManager.instance.ChangeState(GameManager.instance.previousState);
        GameManager.instance.levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void IncreaseProjectile()
    {
        
        int projectileIncrease = 2;

        GameManager.instance.projectileCount += projectileIncrease;
        GameManager.instance.projectileSpreadAngle += 10;
        LevelUpStateHandler();
    }

    public void IncreaseHealth()
    {
        float healthIncrease = 20f;

        GameManager.instance.currentHealth += healthIncrease;
        GameManager.instance.maxHealth += healthIncrease;
        LevelUpStateHandler();
    }

    public void IncreaseArmour()
    {
        float armourIncrease = 2f;

        GameManager.instance.armour += armourIncrease;
        LevelUpStateHandler();
    }

    public void IncreaseDamage()
    {
        // an array of dmg values for higher scaling per pick up might be better?//
        float dmgIncrease = 10f;

        GameManager.instance.dmg += dmgIncrease;
        LevelUpStateHandler();
    }

    public void PiercingProjectile()
    {
        // Should only be able to pierce 1 enemy at lv 1 of this upgrade//

        GameManager.instance.canPierce = true;
        GameManager.instance.numOfPierce++;
        LevelUpStateHandler();
    }

    public void IncreaseShootRate()
    {
        GameManager.instance.startShootCoolDown -= GameManager.instance.shootRate;
        LevelUpStateHandler();
    }

    public void AddHealthRegen()
    {
        // Additional health regen on subsequent pickups//
        // an array of dmg values for higher scaling per pick up might be better?//
        GameManager.instance.healthRegen += 1;
        LevelUpStateHandler();
    }

    public void SpawnSword()
    {
        // Spawn 1 sword around the player that deals damage upon contact
        // Sword should orbit the player
        // Increase number of swords on subsequent pickups
        GameManager.instance.hasTakenSword = true;
        GameManager.instance.numOfSwords++;

        LevelUpStateHandler();
    }

    public void IncreaseMoveSpeed()
    {

    }
}
