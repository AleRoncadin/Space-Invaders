using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public void ClickNewGame()
    {
        Player.isfinish = false;
        SceneManager.LoadScene(1);
    }
    public void ClickOptions()
    {
        SceneManager.LoadScene(2);
    }

    public void ClickBack()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void ClickRestart()
    {
        Player.isfinish = false;
        SceneManager.LoadScene(1);
    }

    public void ClickMenu()
    {
        SceneManager.LoadScene(0);
    }
}
