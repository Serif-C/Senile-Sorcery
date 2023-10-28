using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeUpgrade : MonoBehaviour
{
    public GameObject[] upgradeButtonPrefab;
    public Transform[] buttonPositions;

    private List<int> chosenUpgrades = new List<int>();

    public void ShuffleUpgrades()
    {
        // Clear the list of chosen upgrades before shuffling
        chosenUpgrades.Clear();

        for (int i = 0; i < buttonPositions.Length; i++)
        {
            int randUpgrade;

            // Keep generating a random upgrade until it's not a duplicate
            do
            {
                randUpgrade = Random.Range(0, upgradeButtonPrefab.Length);
            }
            while (chosenUpgrades.Contains(randUpgrade));

            chosenUpgrades.Add(randUpgrade);
            Instantiate(upgradeButtonPrefab[randUpgrade], buttonPositions[i]);
        }
    }
}
