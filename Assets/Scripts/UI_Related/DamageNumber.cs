using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI dmgText;

    private void Start()
    {
        StartCoroutine(DestroyAfterThirtyFrames());
    }

    private void Update()
    {
        dmgText.text = GameManager.instance.dmgDealt + "!";
    }

    private IEnumerator DestroyAfterThirtyFrames()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
