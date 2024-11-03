using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordControll : WeaponBase
{
    [SerializeField] private Animator animator_s;
    [SerializeField] private Weapon swordWeapon;
    [SerializeField] bool isAttacking;
    [SerializeField] Vector2 size;
    public StatusEffectbar statusEffectbar;
    public StatusItemData effectview;
    // Flags to check if the animations have finished
    void Start()
    {
        statusEffectbar = GameObject.FindAnyObjectByType<StatusEffectbar>();
        SetAll(swordWeapon);
    }
    public void addStutusEffect()
    {
        effectview.time = timeToAttack;
        statusEffectbar.AddObject(effectview);
    }
    public void SetAll()
    {
        swordWeapon.damage = weaponStats.damage;
        swordWeapon.knockback = weaponStats.knockback;
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
        Collider2D[] nearbyColliders = Physics2D.OverlapBoxAll(transform.position, new Vector3(size.x, size.y), 0);

        // Check for nearby Enemy objects
        foreach (var collider in nearbyColliders)
        {
            BossBase enemy = collider.GetComponent<BossBase>();
            if (enemy != null)
            {
                Vector3 enemyPosition = enemy.transform.position;
                if (enemyPosition.x > transform.position.x)
                {
                    animator_s.SetTrigger("atkr");
                }
                else if (enemyPosition.x < transform.position.x)
                {
                    animator_s.SetTrigger("atkl");
                }
                addStutusEffect();
                enemy.TakeDamage(swordWeapon.damage);
                timer = timeToAttack;
                break;
            }
            else
            {
                Enemy enemy1 = collider.GetComponent<Enemy>();
                if (enemy1 != null)
                {
                    Vector3 enemyPosition = enemy1.transform.position;
                    if (enemyPosition.x > transform.position.x)
                    {
                        animator_s.SetTrigger("atkr");
                    }
                    else if (enemyPosition.x < transform.position.x)
                    {
                        animator_s.SetTrigger("atkl");
                    }
                    addStutusEffect();
                    timer = timeToAttack;
                    break;
                }
            }
        }
    }

}



