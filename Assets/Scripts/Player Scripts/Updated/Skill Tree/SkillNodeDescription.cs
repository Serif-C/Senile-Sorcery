using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillNodeDescription : MonoBehaviour
{
    public GameObject[] skillNodes;

    public TextMeshProUGUI skillDescription;
    public bool isActive = false;

    private void Update()
    {
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        for (int index = 0; index < skillNodes.Length; index++)
        {
            if (skillNodes[index].GetComponentInChildren<SNode>().skillIsSelected)
            {
                skillNodes[index].GetComponentInChildren<SNode>().skillIsSelected = false;
            }
        }
    }

    public void IncreaseLevel()
    {
        for (int index = 0; index < skillNodes.Length; index++)
        {
            if (skillNodes[index].GetComponentInChildren<SNode>().skillIsSelected)
            {
                if(skillNodes[index].GetComponentInChildren<SNode>().skillCurrentLevel < skillNodes[index].GetComponentInChildren<SNode>().skillMaxLevel)
                {
                    skillNodes[index].GetComponentInChildren<SNode>().skillCurrentLevel++;
                }
            }
        }
    }
}
