using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject Control;
    public GameObject BarrelPanel;
    public AudioSource Click;
    private bool BarrelPanelFirst;
    void Start()
    {
        Time.timeScale = 0;
        Control.SetActive(true);
        BarrelPanelFirst = true;
    }

    public void Close(GameObject panel)
    {
        Click.Play();
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BarrelTrigger") && BarrelPanelFirst)
        {
            BarrelPanel.SetActive(true);
            BarrelPanelFirst = false;
            Time.timeScale = 0;
        }
    }
}
