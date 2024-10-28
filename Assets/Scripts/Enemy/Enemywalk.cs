using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    // The player GameObject that the enemy will follow.
    public GameObject player;

    // The distance within which the enemy starts moving towards the player.
    public float neardetect = 30f;

    // Speed of the enemy movement towards the player.
    public float moveSpeed = 2f;
    public Animator animator;
    public bool isFollow = true;
    public bool isMovingPastPlayer = false; // Flag to check if already moving past player.
    public float smoothMoveDuration = 1.2f; // Duration to move past the player.
    public float x_attacked_move = 2;
    public float y_attacked_move = 2;
    void Awake()
    {
        animator = GetComponent<Animator>();
        isFollow = !true;
        if (player == null)
        {
            player = GameObject.Find("PlayerCharacter");
            isFollow = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isFollow && !isMovingPastPlayer)
        {
            // Check if the player is within the specified distance.
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceToPlayer < neardetect)
            {
                // Move the enemy towards the player.
                Vector3 direction = (player.transform.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
                if (player.transform.position.x < transform.position.x)
                {
                    // Player is to the left of the enemy.
                    animator.Play("walkleft");
                }
                else
                {
                    // Player is to the right of the enemy.
                    animator.Play("walkright");
                }
            }
        }
    }
    private Player b;
    void OnTriggerEnter2D(Collider2D other)
    {
        b = other.gameObject.GetComponent<Player>();
        if (b != null && !isMovingPastPlayer)
        {
            isFollow = false;
            isMovingPastPlayer = true;

            // Start smooth movement to the position past the player.
            StartCoroutine(SmoothMovePastPlayer());
        }
    }

    // Coroutine to smoothly move the enemy to (x + 5, y + 2) relative to the player.
    IEnumerator SmoothMovePastPlayer()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition;

        // Determine the target position based on the player's relative position to the enemy.
        if (player.transform.position.x < transform.position.x)
        {
            // Player is to the left, move enemy to (x - 5, y + 2).
            targetPosition = new Vector3(player.transform.position.x - x_attacked_move, player.transform.position.y + y_attacked_move, transform.position.z);
        }
        else
        {
            // Player is to the right, move enemy to (x + x_attacked_move = 2;, y + 2).
            targetPosition = new Vector3(player.transform.position.x + x_attacked_move, player.transform.position.y + y_attacked_move, transform.position.z);
        }

        float elapsedTime = 0f;

        while (elapsedTime < smoothMoveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / smoothMoveDuration);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame.
        }

        // Ensure the enemy ends exactly at the target position.
        transform.position = targetPosition;

        isMovingPastPlayer = false;

        isFollow = true;
    }
    public void setSpeed(float a){
        this.moveSpeed = a;
    }
}

