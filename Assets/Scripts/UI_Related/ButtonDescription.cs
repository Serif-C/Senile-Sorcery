using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonDescription : MonoBehaviour
{
    private TextMeshProUGUI buttonMainDescription;
    private int projectileIncrease = 2;
    private int armourIncrease = 2;
    private int healthIncrease = 20;
    private int damageIncrease = 10;
    private int increasePierceCount = 1;

    private void Start()
    {
        buttonMainDescription = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        /*switch(GameManager.instance.upgradeType)
        {
            case GameManager.UpgradeType.ARMOUR:
                buttonMainDescription.text = new string("+" + armourIncrease + " Armour");
                break;
            case GameManager.UpgradeType.DAMAGE:
                buttonMainDescription.text = new string("+" + damageIncrease + " Damage");
                break;
            case GameManager.UpgradeType.HEALTH:
                buttonMainDescription.text = new string("+" + healthIncrease + " Max Health");
                break;
            case GameManager.UpgradeType.PROJECTILE:
                buttonMainDescription.text = new string("+" + projectileIncrease + " Projectile");
                break;
            case GameManager.UpgradeType.PIERCE:
                buttonMainDescription.text = new string("+" + increasePierceCount + " Pierce");
                break;

            default:
                break;
        }*/
    }
}
