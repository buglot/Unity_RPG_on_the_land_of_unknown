using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float speed;
    public Vector3 oldPositon;
    Vector3 direction;
    public void setDirection(Vector3 direction){
        this.direction = direction;
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
}
