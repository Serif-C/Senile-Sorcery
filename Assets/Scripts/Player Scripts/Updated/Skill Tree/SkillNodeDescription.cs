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

    private int index;
    private bool canLevelUp;
    private void Update()
    {
        for(index = 0; index < skillNodes.Length; index++)
        {
            SNode node = skillNodes[index].gameObject.GetComponent<SNode>();

            if(node.skillIsSelected == true)
            {
                canLevelUp = true;
            }
            else
            {
                canLevelUp = false;
            }
        }
    }
    public void CloseWindow()
    {
        SNode node = skillNodes[index].gameObject.GetComponent<SNode>();
        gameObject.SetActive(false);
        node.skillIsSelected = false;
    }

    public void IncreaseLevel()
    {
        SNode node = skillNodes[index].gameObject.GetComponent<SNode>();
        if (canLevelUp == true)
        {
            if (node.skillCurrentLevel < node.skillMaxLevel)
            {
                node.skillCurrentLevel++;
            }
        }
    }
}
