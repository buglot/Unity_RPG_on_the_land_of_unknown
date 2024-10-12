using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class ThrowingProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction;
    Vector3 oldPositon;
    [SerializeField] private float range = 10f;
    public void setRange(float a)
    {
        range = a;
    }
    [SerializeField] Enemy2D[] allEnemies;
    [SerializeField] private float speed = 1f;
    SpriteRenderer spriteRenderer1;
    [SerializeField] private bool isFollow=true;
    public void setSpeed(float a)
    {
        speed = a;
    }
    public void setDirection(Enemy2D[] a)
    {
        if(isFollow){
            FollowEnermyCloserMode(a);
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 90f;
        // Rotate the projectile to face the movement direction
        transform.rotation = Quaternion.Euler(0, 0, angle);
        return;

    }
    void Awake()
    {
        spriteRenderer1 = GetComponent<SpriteRenderer>();
        oldPositon = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void FollowEnermyCloserMode(Enemy2D[] a)
    {
        Enemy2D closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        allEnemies = a; // Get all enemies

        foreach (Enemy2D enemy in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            Vector3 directionToEnemy = (closestEnemy.transform.position - transform.position).normalized;
            direction = directionToEnemy; // Update projectile's direction towards closest enemy
        }
    }
}
