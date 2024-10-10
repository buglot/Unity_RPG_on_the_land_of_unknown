using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction;
    Vector3 oldPositon;
    [SerializeField]private float range = 10f;
    public void setRange(float a){
        range = a;
    }
    [SerializeField] private float speed=1f;
    SpriteRenderer spriteRenderer1;
    public void setSpeed(float a){
        speed = a;
    }
    public void setDirection(float x,float y){
        if (x < 0)
            x = -1;
        if (x > 0)
            x = 1;
        
        direction = new Vector3(x, 0);
        if(x<0){
            
            spriteRenderer1.flipY = true;
        }
    }
    void Awake()
    {
        spriteRenderer1 = GetComponent<SpriteRenderer>();
        oldPositon = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed *Time.deltaTime;
        if(transform.position.x >oldPositon.x+range || transform.position.y >oldPositon.y+range){
            Destroy(gameObject);
        }
    }

    void FollowEnermyCloserMode(){

    }
}
