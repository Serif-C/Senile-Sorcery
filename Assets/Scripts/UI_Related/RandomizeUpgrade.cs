using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeUpgrade : MonoBehaviour
{
    public List<GameObject> unlockedUpgrades = new List<GameObject>();
    public List<GameObject> upgradeList = new List<GameObject>();
    public Transform[] buttonPositions;

    private List<int> chosenUpgrades = new List<int>();

    private void AddToList()
    {
        for(int i = 0; i < upgradeList.Count; i++)
        {
            if(upgradeList[i].gameObject.GetComponentInChildren<Upgrades>().skill.isUnlocked == true)
            {
                unlockedUpgrades.Add(upgradeList[i]);
                upgradeList.Remove(upgradeList[i]);
            }
        }
    }
    public void ShuffleUpgrades()
    {
        // Clear the list of chosen upgrades before shuffling
        chosenUpgrades.Clear();
        AddToList();
        for (int i = 0; i < buttonPositions.Length; i++)
        {
            int randUpgrade;

            // Keep generating a random upgrade until it's not a duplicate
            do
            {
                randUpgrade = Random.Range(0, unlockedUpgrades.Count);
            }
            while (chosenUpgrades.Contains(randUpgrade));

            chosenUpgrades.Add(randUpgrade);
            Instantiate(unlockedUpgrades[randUpgrade], buttonPositions[i]);
        }
    }
}
