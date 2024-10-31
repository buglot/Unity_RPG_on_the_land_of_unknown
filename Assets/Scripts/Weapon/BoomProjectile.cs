using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class BoomProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 Direction;
    public float speed = 5f;
    public float rollSpeed = 5f;
    public float timekillanimation = 1.0f;
    bool canRoll = true;
    bool canMove = true;
    [SerializeField] Weapon weapon;
    [SerializeField] Animator animator;
    [SerializeField] Vector2 rangeboom;
    float same;
    bool OnBoom = false;
    public void setDirection(Vector3 vector3)
    {
        Direction = vector3;
    }
    void Start()
    {

    }
    void Update()
    {

        if (canRoll)
            transform.Rotate(Vector3.forward * Time.deltaTime * rollSpeed);

        if (canMove)
        {
            Vector3 direction = (Direction - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }


        same = Vector3.Distance(transform.position, Direction);


        if (same <= 0.01f && !OnBoom)
        {
            canMove = false;
            canRoll = false;
            animator.SetTrigger("boom");
            Collider2D[] box = Physics2D.OverlapBoxAll(transform.position, rangeboom, 0);
            foreach (Collider2D collider in box)
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(weapon.damage*4);
                }
            }

            OnBoom = true;
        }
        if (OnBoom && animator.GetCurrentAnimatorStateInfo(0).IsName("boom") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= timekillanimation)
        {
            Destroy(gameObject);
        }
    }
}
