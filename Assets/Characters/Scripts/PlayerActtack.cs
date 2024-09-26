using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActtack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Weapon weapon;
    void Start()
    {
        if(weapon==null){
            weapon = GetComponentInChildren<Weapon>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && weapon.CanUse){
            animator.SetTrigger("attack");
        }
    }
}
