using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetItem : MonoBehaviour
{
    public float timetoKill = 40f;  // Duration before the magnet object is destroyed if not picked up
    public float TimeUse = 5f;       // Time the magnet effect lasts when picked up
    public StatusItemData data;
    [SerializeField] AudioBase audioBase;
    void Start(){
    
    }
    void Update()
    {
        // Countdown to destroy the object if not used
        if (timetoKill > 0f)
        {
            timetoKill -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Trigger when the player collides with the magnet
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            if (player.blood > 0)
            {
                player.UseMegnet(TimeUse);
                player.AddStatusBar(data);
                audioBase.play();
                Destroy(gameObject);
            }
        }
    }
}
