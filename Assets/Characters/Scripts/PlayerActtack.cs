using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActtack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            animator.SetTrigger("attack");
        }
    }
}
