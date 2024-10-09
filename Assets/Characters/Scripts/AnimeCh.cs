using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeCh : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public float horizontal;
    public float vertical;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    public void play(string a){
        animator.Play(a);
    }
    // Update is called once per frame
    public void setDead(bool a){
        animator.SetBool("dead",a);
    }
    void Update()
    {
        animator.SetFloat("l",horizontal);
        animator.SetFloat("v",vertical);
    }
}
