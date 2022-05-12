using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject PausePanel;
    public AudioSource Click;

    private bool paused;
    private void Start()
    {
        paused = false;
        PausePanel.SetActive(false);
    }
    public void OnPause()
    {
        Click.Play();
        if (paused)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        paused = !paused;
    }
    
    public void Restart()
    {
        Click.Play();
        Time.timeScale = 1;
        paused = false;
        PausePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Click.Play();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }
}
