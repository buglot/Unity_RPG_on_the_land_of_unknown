using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CatRun : MonoBehaviour
{
    private float inputh;
    private float Inputy;
    public float speed = 10;
    public Animator animator;
    public bool isFacingRight = true;
    public bool isFacingRight1 = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputh = Input.GetAxis("Horizontal");
        Inputy = Input.GetAxis("Vertical");

        

        if (inputh != 0)
        {
            // Check if the character needs to flip
            if (inputh > 0 && !isFacingRight)
            {
                // Flip to face right
                transform.Rotate(new Vector3(0, 180, 0));
                isFacingRight = true;
                
            }
            else if (inputh < 0 && isFacingRight)
            {
                // Flip to face left
                transform.Rotate(new Vector3(0, 180, 0));
                isFacingRight = false;
            }
            if(isFacingRight){
                transform.Translate(Vector3.left * speed * Time.deltaTime * -inputh);
            }else{
                transform.Translate(Vector3.left * speed * Time.deltaTime * inputh);
            }
            
            // Play running animation
            animator.Play("runCat");
            
        }
        else
        {
            // Play idle animation
            animator.Play("IdleCat");
        }
    }
}
