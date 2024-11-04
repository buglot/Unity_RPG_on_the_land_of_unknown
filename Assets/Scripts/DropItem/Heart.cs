using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    private Player b;
    private Animator _animator;
    [SerializeField] private bool CanUse = true;
    [SerializeField] AudioBase audioBase;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        b = other.gameObject.GetComponent<Player>();
        if (b != null)
        {
            if (b.blood > 0)
            {
                if (CanUse)
                {
                    b.AddBlood(health);
                    CanUse = false;
                    _animator.SetTrigger("broke");
                    audioBase.play();
                    StartCoroutine(DestroyAfterAnimation());
                }

            }

        }
    }
    private IEnumerator DestroyAfterAnimation()
    {
        // Wait for the animation to finish
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject); // Destroy the Heart object
    }
}
