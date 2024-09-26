using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActtack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Weapon weapon;
    public bool isAttacking = false;

    void Update()
    {
        // Check if the left mouse button is pressed and the weapon is ready to use
        if (Input.GetMouseButtonDown(0) && weapon.CanUse && !isAttacking)
        {
            Attack();
        }

        // Check if the attack animation is done
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (isAttacking && (stateInfo.IsName("acttackright") ||stateInfo.IsName("acttackleft")))
        {
            // Check if the animation has finished (normalizedTime >= 1)
            if (stateInfo.normalizedTime >= 0.4f)
            {
                isAttacking = false;  // Allow further attacks once animation is done
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack"); // Trigger attack animation
        isAttacking = true;            // Set isAttacking to true to prevent spamming
        // Handle weapon usage (e.g., reduce durability or ammo)
    }
    void Start()
    {
        if(weapon==null){
            weapon = GetComponentInChildren<Weapon>();
        }
    }
}
