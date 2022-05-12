using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    private int stars;
    public GameObject[] Stars; 
    public void StartLevel(int level)
    {
        SceneManager.LoadSceneAsync(level + 1);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Stars"))
        {
            stars = PlayerPrefs.GetInt("Stars");
        }
        else
        {
            stars = 0;
        }
        for(int i = 0; i < Stars.Length / 3; i++)
        {
            SetStars(i);
        }
    }

    private void SetStars(int num) 
    {
        if (stars / Convert.ToInt32(Mathf.Pow(10, num)) % 10 >= 1)
        {
            Stars[num * 3].SetActive(true);
        }
        if (stars / Convert.ToInt32(Mathf.Pow(10, num)) % 10 >= 2)
        {
            Stars[num * 3 + 1].SetActive(true);
        }
        if (stars / Convert.ToInt32(Mathf.Pow(10, num)) % 10 >= 3)
        {
            Stars[num * 3 + 2].SetActive(true);
        }

    }

    [ContextMenu("DeleteKeys")]
    private void DeleteKeys()
    {
        PlayerPrefs.DeleteAll();
    }
}
