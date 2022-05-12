using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrggersScript : MonoBehaviour
{

    public Animator[] doors;
    public Animator Empty;
    public Animator Star;
    public GameObject PressE;
    public GameObject DieParticles;
    public GameObject BarrelParticles;
    public MeshRenderer Player;
    public AudioSource StarAudio;
    public AudioSource DieAudio;

    private int stars;
    private bool isstar1;
    private bool isstar2;
    private bool isstar3;

    private bool countFirst;
    private void Awake()
    {
        Player.enabled = true;
        DieParticles.SetActive(false);
        BarrelParticles.SetActive(false);
        stars = 0;
        isstar1 = false;
        isstar2 = false;
        isstar3 = false;
        countFirst = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish") && countFirst)
        {
            stars *= Convert.ToInt32(Mathf.Pow(10, SceneManager.GetActiveScene().buildIndex - 2));
            if (PlayerPrefs.HasKey("Stars"))
            {
                int p = PlayerPrefs.GetInt("Stars");
                int r = Convert.ToInt32(Mathf.Pow(10, SceneManager.GetActiveScene().buildIndex - 2)); //я слишком запуталась, поэтому для уравнения мне проще буковками
                p = p - (p % (r * 10)) + (p % r);
                stars += p;
            }
            PlayerPrefs.SetInt("Stars", stars);
            countFirst = false;
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        if (other.CompareTag("GameOver"))
        {
            DieAudio.Play();
            StartCoroutine(Die());
        }
        if (other.CompareTag("DoorTrigger"))
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetTrigger("Open");
            }
        }
        if (other.CompareTag("Empty") || other.CompareTag("Star1") || other.CompareTag("Star2") || other.CompareTag("Star3"))
        {
            PressE.SetActive(true);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Empty"))
            {
                Empty.SetTrigger("Empty");
            }

            if (other.CompareTag("Star1") && !isstar1)
            {
                Star.SetTrigger("Star");
                isstar1 = true;
                stars++;
                BarrelParticles.transform.position = other.transform.position;
                StarAudio.Play();
                StartCoroutine(StarParticles());
            }
            if (other.CompareTag("Star2") && !isstar2)
            {
                Star.SetTrigger("Star");
                isstar2 = true;
                stars++;
                BarrelParticles.transform.position = other.transform.position;
                StarAudio.Play();
                StartCoroutine(StarParticles());
            }
            if (other.CompareTag("Star3") && !isstar3)
            {
                Star.SetTrigger("Star");
                isstar3 = true;
                stars++;
                BarrelParticles.transform.position = other.transform.position;
                StarAudio.Play();
                StartCoroutine(StarParticles());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Empty") || other.CompareTag("Star1") || other.CompareTag("Star2") || other.CompareTag("Star3"))
        {
            PressE.SetActive(false);
        }
    }
    private IEnumerator Die()
    {
        DieParticles.transform.position = Player.transform.position;
        Player.enabled = false;
        DieParticles.SetActive(true); 
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private IEnumerator StarParticles()
    {
        BarrelParticles.SetActive(true);
        yield return new WaitForSeconds(1);
        BarrelParticles.SetActive(false);
    }
}
