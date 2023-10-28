using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusTexts : MonoBehaviour
{
    public TextMeshProUGUI level;
    public TextMeshProUGUI currentExp;
    public TextMeshProUGUI requiredExp;
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI armour;
    public TextMeshProUGUI projCount;
    public TextMeshProUGUI pierceCount;
    public TextMeshProUGUI attackRate;

    private void Update()
    {
        LevelText();
        CurrentEXPText();
        RequiredEXPText();
        HealthText();
        DamageText();
        ArmourText();
        ProjText();
        PierceText();
        AttackRateText();
    }

    private void LevelText()
    {
        level.text = "Level: " + GameManager.instance.lvl;
    }

    private void CurrentEXPText()
    {
        currentExp.text = "Current Experience: " + GameManager.instance.currentExp;
    }

    private void RequiredEXPText()
    {
        requiredExp.text = "Required Experience: " + GameManager.instance.expNeeded;
    }

    private void HealthText()
    {
        health.text = "Health: " + GameManager.instance.currentHealth + " / " + GameManager.instance.maxHealth;
    }

    private void DamageText()
    {
        damage.text = "Damage: " + GameManager.instance.dmg;
    }

    private void ArmourText()
    {
        armour.text = "Armour: " + GameManager.instance.armour;
    }

    private void ProjText()
    {
        projCount.text = "Projectile Count: " + GameManager.instance.projectileCount;
    }

    private void PierceText()
    {
        pierceCount.text = "Pierce Count: " + GameManager.instance.numOfPierce;
    }

    private void AttackRateText()
    {
        attackRate.text = "Attack Rate: " + GameManager.instance.startShootCoolDown;
    }
}
