using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float moveSpeed = 10f;
    private bool isMoving = false;
    public Vector2 Input1;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            Input1.x = Input.GetAxisRaw("Horizontal");
            Input1.y = Input.GetAxisRaw("Vertical");
            
            animator.SetFloat("moveX", Input1.x);
            animator.SetFloat("moveY", Input1.y);
            if (Input1.x <0){
                animator.SetBool("left",true);
            }else if(Input1.x >0){
                animator.SetBool("left",false);
            }
            if (Input1 != Vector2.zero)
            {
                
                isMoving = true;

                transform.Translate(Vector2.right * Input1.x * moveSpeed * Time.deltaTime);
                transform.Translate(Vector2.up * Input1.y * moveSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false; 
            }
        
        animator.SetBool("isMoving", isMoving);
    }
}
