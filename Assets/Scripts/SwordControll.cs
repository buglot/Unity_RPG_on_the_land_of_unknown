using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControll : MonoBehaviour
{
    [SerializeField] private Animator animator_s;
    [SerializeField] private float Damage=100f;
    [SerializeField] private Weapon swordWeapon;
    float screenMiddle;
    [SerializeField] bool isAttacking;
    [SerializeField] private float timeToAtteck = 1f;
    [SerializeField] private float timer;

    // Flags to check if the animations have finished
    void Start()
    {
        // Get the middle of the screen in screen coordinates
        swordWeapon = GetComponentInChildren<Weapon>();
        screenMiddle = Screen.width / 2;
        swordWeapon.damage = Damage;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce the attack cooldown timer
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Atteck();
        }
    }

    public void Atteck()
    {
        Vector3 mousePosition = Input.mousePosition;
        isAttacking = Input.GetMouseButton(0);

        // Check if the left mouse button is pressed and trigger attack animation
        if (isAttacking)
        {
            timer = timeToAtteck;
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
