using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;

    public TextMeshProUGUI upgradeDescription;
    public Image upgradeArtwork;
    public Button upgradeButton;

    private void Start()
    {
        upgradeDescription.text = upgrade.upgradeDescription;
        upgradeArtwork.sprite = upgrade.upgradeArtwork;
        upgradeButton.onClick = upgradeButton.onClick;
    }
}
