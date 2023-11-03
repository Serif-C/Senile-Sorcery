using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillNodeDescription : MonoBehaviour
{
    public SkillNode[] skillNode;

    public TextMeshProUGUI skillDescription;

    private void Update()
    {
        for(int i = 0; i < skillNode.Length; i++)
        {
            skillDescription.text = skillNode[i].description;
        }
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
