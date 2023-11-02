using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Skill")]
public class SkillNode : ScriptableObject
{
    public string name;
    public string description;
    public Sprite artwork;
    public int currentLevel;
    public int maxLevel;
    public List<SkillNode> prerequisite = new List<SkillNode>();
}
