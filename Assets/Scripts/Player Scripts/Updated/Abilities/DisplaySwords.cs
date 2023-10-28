using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaySwords : MonoBehaviour
{
    public GameObject[] swords;
    public Transform playerTransform;

    private void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * GameManager.instance.orbitSpeed);
        transform.position = playerTransform.position;

        if (GameManager.instance.hasTakenSword == true)
        {
            int activeSwords = GameManager.instance.numOfSwords;

            for (int i = 0; i < swords.Length; i++)
            {
                swords[i].SetActive(i < activeSwords);
            }
        }
    }
}
