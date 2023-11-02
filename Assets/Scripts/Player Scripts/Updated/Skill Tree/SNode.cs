using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SNode : MonoBehaviour
{
    public SkillNode skillNode;

    public string skillName;
    public TextMeshProUGUI skillDescription;
    public Image skillImage;
    public int skillCurrentLevel;
    public int skillMaxLevel;

    private void Update()
    {
        skillName = skillNode.name;
        skillDescription.text = skillNode.description;
        skillImage.sprite = skillNode.artwork;
        skillCurrentLevel = skillNode.currentLevel;
        skillMaxLevel = skillNode.maxLevel;
    }
}
