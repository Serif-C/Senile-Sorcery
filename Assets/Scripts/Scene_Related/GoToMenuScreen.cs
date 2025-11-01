using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMenuScreen : MonoBehaviour
{
    public void GoMenuScreen()
    {
        SceneManager.LoadScene("PreGame");
    }
}
