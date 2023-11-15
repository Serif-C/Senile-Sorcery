using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    /* After choosing an upgrade (pressing the button) go back to GamePlay State
     * Remove the levelup screen
     * Then change timescale back to 1 (from 0/paused) */
    public SkillNode skill;

    private int projectileUpgrade;
    private float armourUpgrade;
    private float healthUpgrade;
    private float health2Upgrade;
    private float dmgUpgrade;
    private int pierceUpgrade;


    private void LevelUpStateHandler()
    {
        GameManager.instance.ChangeState(GameManager.instance.previousState);
        GameManager.instance.levelUpScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void IncreaseProjectile()
    {
        if (skill.name.CompareTo("Projectile 1") == 0)
        {
            projectileUpgrade = skill.currentLevel * 1;
        }
        int projectileIncrease = 1 + projectileUpgrade;

        GameManager.instance.projectileCount += projectileIncrease;
        GameManager.instance.projectileSpreadAngle += (10 * (GameManager.instance.projectileCount / 2));
        LevelUpStateHandler();
    }

    public void IncreaseHealth()
    {
        if(skill.name.CompareTo("Health 1") == 0)
        {
            healthUpgrade = skill.currentLevel * 20f;
        }

        float healthIncrease = 20f + healthUpgrade;

        GameManager.instance.currentHealth += healthIncrease;
        GameManager.instance.maxHealth += healthIncrease;
        LevelUpStateHandler();
    }

    public void IncreaseArmour()
    {
        if (skill.name.CompareTo("Armour 1") == 0)
        {
            armourUpgrade = skill.currentLevel * 2;
        }

        float armourIncrease = 2f + armourUpgrade;

        GameManager.instance.armour += armourIncrease;
        LevelUpStateHandler();
    }

    public void IncreaseDamage()
    {
        // an array of dmg values for higher scaling per pick up might be better?//
        if (skill.name.CompareTo("Damage 1") == 0)
        {
            dmgUpgrade = skill.currentLevel * 10f;
        }
            float dmgIncrease = 10f + dmgUpgrade;

        GameManager.instance.dmg += dmgIncrease;
        LevelUpStateHandler();
    }

    public void PiercingProjectile()
    {
        // Should only be able to pierce 1 enemy at lv 1 of this upgrade//
        if (skill.name.CompareTo("Pierce 1") == 0)
        {
            pierceUpgrade = skill.currentLevel * 1;
        }

        int pierceIncrease = 1 + pierceUpgrade;
        GameManager.instance.canPierce = true;
        GameManager.instance.numOfPierce += pierceIncrease;
        LevelUpStateHandler();
    }

    public void IncreaseShootRate()
    {
        GameManager.instance.startShootCoolDown -= GameManager.instance.shootRate;
        LevelUpStateHandler();
    }

    public void AddHealthRegen()
    {
        if (skill.name.CompareTo("Health 2") == 0)
        {
            health2Upgrade = skill.currentLevel * 1;
        }

        GameManager.instance.healthRegen += (1 + health2Upgrade);
        LevelUpStateHandler();
    }

    public void AddExplosion()
    {
        GameManager.instance.canPierce = false;

        if(GameManager.instance.currentElementType != GameManager.Elements.Fire)
        {
            GameManager.instance.currentElementType = GameManager.Elements.Fire;
        }

        GameManager.instance.explosionDmgMultiplier += 0.1f;

        LevelUpStateHandler();
    }

    public void AddShiled()
    {

    }

    public void AddThorns()
    {

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

    public void IncreaseExpGain()
    {

    }
}
