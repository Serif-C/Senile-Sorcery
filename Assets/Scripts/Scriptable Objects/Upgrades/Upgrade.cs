using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Create new Upgrade")]
public class Upgrade : ScriptableObject
{
    public string upgradeDescription;
    public Sprite upgradeArtwork;
    public Button upgradeButton;
}
