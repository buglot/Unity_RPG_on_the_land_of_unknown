using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControll : WeaponBase
{
    [SerializeField] private Animator animator_s;
    [SerializeField] private Weapon swordWeapon;
    float screenMiddle;
    [SerializeField] bool isAttacking;
    // Flags to check if the animations have finished
    void Start()
    {
        // Get the middle of the screen in screen coordinates
        swordWeapon = GetComponentInChildren<Weapon>();
        screenMiddle = Screen.width / 2;
        swordWeapon.damage = weaponStats.damage;
        SetAll(swordWeapon);
    }

    // Update is called once per frame
    public void Update()
    {
        // Reduce the attack cooldown timer
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    public override void Attack()
    {
        Vector3 mousePosition = Input.mousePosition;
        isAttacking = Input.GetMouseButton(0);

        // Check if the left mouse button is pressed and trigger attack animation
        if (isAttacking)
        {
            timer = timeToAttack;
            if (mousePosition.x > screenMiddle)
            {
                // Attack to the right
                animator_s.SetTrigger("atkr");  // Right sword animation
            }
            else if (mousePosition.x < screenMiddle)
            {
                animator_s.SetTrigger("atkl");  // Left sword animation
            }
        }
    }


}
