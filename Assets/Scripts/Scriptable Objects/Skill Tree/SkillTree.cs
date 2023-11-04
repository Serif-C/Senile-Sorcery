using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    public List<SkillNode> allSkillNodes;
    public GameObject skillDescriptionBox;


    private void Update()
    {
        for(int i = 0; i < allSkillNodes.Count; i++)
        {
            UnlockSkill(allSkillNodes[i]);
        }
    }
    public void DescriptionWindow(SkillNode skill)
    {
        skillDescriptionBox.SetActive(true);
        SkillNodeDescription descriptionWindow = skillDescriptionBox.gameObject.GetComponent<SkillNodeDescription>();

        descriptionWindow.skillDescription.text = skill.description;
    }

    public void IncreaseSkillLevel(GameObject skillDescriptionBox)
    {
        
    }

    private void UnlockSkill(SkillNode skill)
    {
        if (CanUnlockSkill(skill))
        {
            // Logic to unlock the skill
            skill.isUnlocked = true;
            Debug.Log("Skill " + skill.name + " - can be unlocked!");
        }
    }

    // can unlock skill is true when prerequisite skill has reached max level otherwise, false
    private bool CanUnlockSkill(SkillNode skill)
    {
        for(int i = 0; i < skill.prerequisite.Count; i++)
        {
            if (skill.prerequisite[i].currentLevel < skill.prerequisite[i].maxLevel)
            {
                return false;
            }
        }
        return true;
    }
}
