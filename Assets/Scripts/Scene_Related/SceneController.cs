using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject[] screens;
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OpenUpgradeScreen()
    {
        screens[0].gameObject.SetActive(true);
    }
}
