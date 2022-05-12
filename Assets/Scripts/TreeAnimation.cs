using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimation : MonoBehaviour
{
    public Animator anim;
    private int num;
    public void NextAnim()
    {
        num = Random.Range(0, 3);
        if (num == 0) anim.SetTrigger("Round");
        else if (num == 1) anim.SetTrigger("Go");
        else anim.SetTrigger("UpDown");
    }
}
