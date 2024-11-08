using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class KnockbackEnemies : MonoBehaviour
{
    public float knockbackResistance = 1f;  // Enemy's resistance to knockback
    private Weapon weapon;  // Reference to the weapon hitting the enemy
    public float smoothMoveDuration = 1f;  // Duration for smooth knockback movement
    public EnemyWalk enemyWalk;
    void Start(){
        if(enemyWalk != null){
            enemyWalk = GetComponent<EnemyWalk>();
        }
          
    }
    public void ApplyProgress(float progress){
        knockbackResistance += knockbackResistance * progress * 0.3f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the enemy is hit by a weapon.
        weapon = other.gameObject.GetComponent<Weapon>();
        if (weapon != null)
        {
            // Calculate knockback effect based on the weapon's knockback and enemy's resistance.
            doKnockback(weapon.knockback);
        }
    }
    public void doKnockback(float knock){
        float knockback = (knock * 0.5f) - knockbackResistance;
            if (knockback<=0){
                knockback = -0.7f;
            }
            // Disable enemy follow and initiate knockback movement.
            if (enemyWalk == null) {
                return;
            }
            enemyWalk.isFollow = false;
            enemyWalk.isMovingPastPlayer = true;

            // Start smooth knockback movement using the calculated knockback.
            StartCoroutine(SmoothMovePastPlayer(knockback));
    }
    // Coroutine to smoothly knock the enemy back by knockback value in x and y direction.
    IEnumerator SmoothMovePastPlayer(float knockback)
    {
        Vector3 startPosition = transform.position;

        // Determine the knockback direction based on player's relative position.
        Vector3 direction;
        if (enemyWalk.player.transform.position.x < transform.position.x)
        {
            // Player is to the left of the enemy, knockback to the right.
            direction = new Vector3(1, 1, 0).normalized;
        }
        else
        {
            // Player is to the right of the enemy, knockback to the left.
            direction = new Vector3(-1, 1, 0).normalized;
        }

        // Calculate the target position for knockback.
        Vector3 targetPosition = startPosition + direction * knockback;

        float elapsedTime = 0f;

        // Smoothly move the enemy to the knockback target position over time.
        while (elapsedTime < smoothMoveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / smoothMoveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame.
        }

        // Ensure the enemy ends exactly at the target position after knockback.
        transform.position = targetPosition;

        // Re-enable enemy follow behavior.
        enemyWalk.isMovingPastPlayer = false;
        enemyWalk.isFollow = true;
    }
}
