using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordControll : MonoBehaviour
{
    [SerializeField] private GameObject swordObject;
    [SerializeField] private GameObject effectObject;
    [SerializeField] private Animator animator_s;
    [SerializeField] private Animator animator_ef;
    float screenMiddle;
    [SerializeField] bool isAttacking;
    [SerializeField] private float timeToAtteck = 1f;
    [SerializeField] private float timer;

    // Flags to check if the animations have finished
    private bool swordAnimationFinished = false;
    private bool effectAnimationFinished = false;

    void Start()
    {
        // Get the middle of the screen in screen coordinates
        screenMiddle = Screen.width / 2;
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

        // Check the animation status for both sword and effect animations
        CheckAnimationStatus();
    }

    public void Atteck()
    {
        Vector3 mousePosition = Input.mousePosition;
        isAttacking = Input.GetMouseButton(0);

        // Check if the left mouse button is pressed and trigger attack animation
        if (isAttacking)
        {
            timer = timeToAtteck;

            // Reset flags when starting a new attack
            swordAnimationFinished = false;
            effectAnimationFinished = false;

            if (mousePosition.x > screenMiddle)
            {
                // Attack to the right
                swordObject.SetActive(true);
                effectObject.SetActive(true);
                animator_ef.SetTrigger("atkr"); // Right effect animation
                animator_s.SetTrigger("atkr");  // Right sword animation
            }
            else if (mousePosition.x < screenMiddle)
            {
                // Attack to the left
                swordObject.SetActive(true);
                effectObject.SetActive(true);
                animator_ef.SetTrigger("atkl"); // Left effect animation
                animator_s.SetTrigger("atkl");  // Left sword animation
            }
        }
    }

    void CheckAnimationStatus()
    {
        // Check the sword animation state
        AnimatorStateInfo swordStateInfo = animator_s.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo effectStateInfo = animator_ef.GetCurrentAnimatorStateInfo(0);

        // Check if the sword animation has finished
        if (swordStateInfo.normalizedTime >= 1f && !animator_s.IsInTransition(0))
        {
            swordAnimationFinished = true;
        }

        // Check if the effect animation has finished
        if (effectStateInfo.normalizedTime >= 1f && !animator_ef.IsInTransition(0))
        {
            effectAnimationFinished = true;
        }

        // If both animations are finished, deactivate the objects
        if (swordAnimationFinished && effectAnimationFinished)
        {
            swordObject.SetActive(false);
            effectObject.SetActive(false);
        }
    }
}
