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
            if (skillNodes[index].GetComponentInChildren<SNode>().skillNode.isSelected)
            {
                skillNodes[index].GetComponentInChildren<SNode>().skillNode.isSelected = false;
            }
        }
    }

    public void IncreaseLevel()
    {
        for (int index = 0; index < skillNodes.Length; index++)
        {
            if (skillNodes[index].GetComponentInChildren<SNode>().skillNode.isSelected)
            {
                if(skillNodes[index].GetComponentInChildren<SNode>().skillNode.currentLevel < skillNodes[index].GetComponentInChildren<SNode>().skillNode.maxLevel)
                {
                    skillNodes[index].GetComponentInChildren<SNode>().skillNode.currentLevel++;
                }
            }
        }
    }
}
