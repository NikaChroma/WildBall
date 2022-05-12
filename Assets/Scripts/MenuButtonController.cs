using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour
{
    public GameObject HelpPanel;
    public AudioSource Click;
    public void StartGame()
    {
        Click.Play();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Click.Play();
        Application.Quit();
    }

    public void Help()
    {
        Click.Play();
        HelpPanel.SetActive(true);
    }

    public void CloseHelp()
    {
        Click.Play();
        HelpPanel.SetActive(false);
    }
}
