using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghasts : MonoBehaviour
{
    public float expReward = 1500f;
    public bool hasGivenExp = false;
    public Enemy enemy;
    private void Start()
    {
        enemy.isEnemyMelee = false;
    }

    public void OnEnemyDeath()
    {
        if (!hasGivenExp)
        {
            hasGivenExp = true;
            addEXP(expReward);
        }
    }

    void addEXP(float exp)
    {
        GameManager.instance.currentExp += exp;
        Debug.Log($"EXP +{expReward} from {gameObject.name}");
    }
}
