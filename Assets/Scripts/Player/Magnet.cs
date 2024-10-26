using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject canvas;
    public float timeToUse = 3f; // Duration of the magnet effect
    public float speed = 15f;      // Speed at which items are attracted
    [SerializeField] Vector2 range = new Vector2(5f, 5f); // Range in which items are attracted
    private float timer;

    private Experience[] experiences;
    private Heart[] hearts;

    void Start()
    {
        timer = timeToUse;
    }
    public void SetTimeUse(float a){
        timer = a;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            // Decrease timer
            timer -= Time.deltaTime;

            // Load nearby items
            loadItem();
            canvas.SetActive(true);
            // Attract items
            AttractItems();
        }else{
            canvas.SetActive(false);
        }
    }

    // Load Experience and Heart objects within range
    void loadItem()
    {
        // Find all Experience and Heart objects within the specified range
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, range, 0);
        List<Experience> foundExperiences = new List<Experience>();
        List<Heart> foundHearts = new List<Heart>();

        foreach (Collider2D collider in colliders)
        {
            Experience exp = collider.GetComponent<Experience>();
            if (exp != null)
            {
                foundExperiences.Add(exp);
            }

            Heart heart = collider.GetComponent<Heart>();
            if (heart != null)
            {
                foundHearts.Add(heart);
            }
        }

        experiences = foundExperiences.ToArray();
        hearts = foundHearts.ToArray();
    }

    // Attract Experience and Heart objects towards the player
    void AttractItems()
    {
        // Move Experience items towards the player
        foreach (Experience exp in experiences)
        {
            if (exp != null)
            {
                exp.transform.position = Vector2.MoveTowards(exp.transform.position, transform.position, speed * Time.deltaTime);
            }
        }

        // Move Heart items towards the player
        foreach (Heart heart in hearts)
        {
            if (heart != null)
            {
                heart.transform.position = Vector2.MoveTowards(heart.transform.position, transform.position, speed * Time.deltaTime);
            }
        }
    }

    // Draw the attraction range in the Scene view for debugging
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, range);
    }
}
