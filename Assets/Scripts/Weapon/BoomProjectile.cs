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
    [SerializeField] AudioBase audioBase;
    Vector3 Direction;
    public float speed = 5f;
    public float rollSpeed = 5f;
    public float timekillanimation = 1.0f;
    bool canRoll = true;
    bool canMove = true;
    public float bonus = 10;
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
                BossBase boss = collider.GetComponent<BossBase>();
                if (boss != null)
                {
                    boss.TakeDamage(weapon.damage * bonus);
                    Debug.Log("boss boom " + weapon.damage * bonus);
                }
                else
                {
                    EnemyManager enemy = collider.GetComponent<EnemyManager>();

                    if (enemy != null)
                    {
                        enemy.Knockback(weapon.knockback * bonus);
                        enemy.TakeDamage(weapon.damage * bonus);
                    }
                }


            }
            OnBoom = true;
            audioBase.play();
        }
        if (OnBoom && animator.GetCurrentAnimatorStateInfo(0).IsName("boom") &&
        animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= timekillanimation)
        {
            Destroy(gameObject);
        }
    }
}
