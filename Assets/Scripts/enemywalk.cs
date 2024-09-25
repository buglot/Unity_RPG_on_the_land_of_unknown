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
    void Start(){
        animator = GetComponent<Animator>();
        if(player ==null){
           player = GameObject.Find("Player");
        }
    }
    // Update is called once per frame
    void Update()
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
