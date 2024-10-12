using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class PlayerCharacter_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2D_;
    Vector3 moveVector;
    [SerializeField] float moveSpeed = 3f;
    AnimeCh animetor_PlayCharacter;
    private bool canMove=true;
    public float lastHorizontal;
    public float lastVertical;

    public void CanMove(bool a)
    {
        canMove = a;
    }
    public void SetSpeed(float a){
        moveSpeed = a;
    }
    void Start()
    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();
        moveVector = new Vector3();
        animetor_PlayCharacter = GetComponent<AnimeCh>();
    }

    // Update is called once per frame
    public UnityEvent OnMove;
    void Update()
    {

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        animetor_PlayCharacter.horizontal = moveVector.x;
        animetor_PlayCharacter.vertical = moveVector.y;
        if(moveVector.x !=0){
            lastHorizontal = moveVector.x;
        }
        if(moveVector.y!=0){
            lastVertical = moveVector.y;
        }
        if (canMove)
        {
            moveVector *= moveSpeed;
            rigidbody2D_.velocity = moveVector;
            OnMove.Invoke();
        }else{
            moveVector *= 0;
            rigidbody2D_.velocity = moveVector;
        }
        

    }
}
