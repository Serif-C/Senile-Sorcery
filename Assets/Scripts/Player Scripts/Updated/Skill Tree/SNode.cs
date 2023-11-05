using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SNode : MonoBehaviour
{
    public SkillNode skillNode;

    public string skillName;
    public TextMeshProUGUI skillLevelText;
    public Image skillImage;
    public int skillCurrentLevel;
    public int skillMaxLevel;
    public bool skillIsUnlocked;
    public List<SkillNode> skillPrerequisites;

    public bool skillIsSelected;
    private void Update()
    {
        skillName = skillNode.name;
        skillLevelText.text = skillNode.currentLevel.ToString();
        skillImage.sprite = skillNode.artwork;
        skillCurrentLevel = skillNode.currentLevel;
        skillMaxLevel = skillNode.maxLevel;
        skillIsUnlocked = skillNode.isUnlocked;
        skillPrerequisites = skillNode.prerequisite;
        skillIsSelected = skillNode.isSelected;
    }
}
