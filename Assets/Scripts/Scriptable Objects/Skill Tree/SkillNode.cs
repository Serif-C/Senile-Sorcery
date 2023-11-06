using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill")]
public class SkillNode : ScriptableObject
{
    public string name;
    public string description;
    public int cost;
    public Sprite artwork;
    public int currentLevel;
    public int maxLevel;
    public bool isUnlocked;
    public bool isSelected;
    public List<SkillNode> prerequisite = new List<SkillNode>();
}
