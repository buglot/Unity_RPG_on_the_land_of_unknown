using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class ThrowingProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction;
    public Vector3 oldPositon;
    [SerializeField] Enemy[] allEnemies;
    [SerializeField] private float speed = 1f;
    SpriteRenderer spriteRenderer1;
    
    [SerializeField] private bool isFollow = true;
    public void setSpeed(float a)
    {
        speed = a;
    }

    public void setDirection(Enemy[] a)
    {
        if (isFollow)
        {
            FollowEnermyCloserMode(a);
        }
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 90f;
        // Rotate the projectile to face the movement direction
        transform.rotation = Quaternion.Euler(0, 0, angle);
        oldPositon = transform.position;
        return;

    }
    void Awake()
    {
        spriteRenderer1 = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        // Calculate the distance from the old position
        float deltaX = Mathf.Abs(transform.position.x - oldPositon.x);
        float deltaY = Mathf.Abs(transform.position.y - oldPositon.y);

        // Check if the projectile has moved more than 30 units in any direction
        if (deltaX > 30f || deltaY > 30f)
        {
            // Destroy the projectile if it's more than 30 units away from the old position
            Destroy(gameObject);
        }
    }

    void FollowEnermyCloserMode(Enemy[] a)
    {
        Enemy closestEnemy = null;
        float closestDistance = Mathf.Infinity;
        allEnemies = a; // Get all enemies

        foreach (Enemy enemy in allEnemies)
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
