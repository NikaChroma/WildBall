using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelAnimation : MonoBehaviour
{
    public Animator anim;
    private int num;
    public void NextAnim()
    {
        num = Random.Range(0, 2);
        if (num == 0) anim.SetTrigger("Stay");
        else anim.SetTrigger("Go");
    }
}
