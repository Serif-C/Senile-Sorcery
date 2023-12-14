using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldTimer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        GameManager.instance.elapsedTime = Time.time - startTime;
        GameManager.instance.minutes = Mathf.FloorToInt(GameManager.instance.elapsedTime / 60);
        GameManager.instance.seconds = Mathf.FloorToInt(GameManager.instance.elapsedTime % 60);

        if(GameManager.instance.hasReset == true)
        {
            GameManager.instance.elapsedTime = 0;
            GameManager.instance.minutes = 0;
            GameManager.instance.seconds = 0;
        }

        string timerString = string.Format("{0:00}:{1:00}", GameManager.instance.minutes, GameManager.instance.seconds);
        timerText.text = timerString;
    }
}
