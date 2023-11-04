using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillNodeDescription : MonoBehaviour
{
    public SkillNode[] skillNode;

    public TextMeshProUGUI skillDescription;

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }

    /*public void IncreaseSkillLevel(SNode node, SkillNode skill)
    {
        for(int i = 0; i < skillNode.Length; i++)
        {

        }

        if (skill.isUnlocked && (skill.currentLevel < skill.maxLevel))
        {
            skill.currentLevel++;
        }
    }*/
}
