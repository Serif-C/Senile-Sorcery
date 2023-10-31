using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Preserved Stats")]
public class CurrentRunStats : ScriptableObject
{
    public int currentLvl;
    public float currentEXP;
    public float currentReqEXP;
    public float currentHealth;
    public float currentDmg;
    public float currentArmour;
    public int currentProjCount;
    public int currentPierceCount;
}
