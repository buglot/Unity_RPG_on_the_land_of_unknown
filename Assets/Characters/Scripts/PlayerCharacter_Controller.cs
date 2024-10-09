using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCharacter_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2D;
    Vector3 moveVector;
    [SerializeField] float moveSpeed=3f;
    AnimeCh animetor_PlayCharacter;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        moveVector = new Vector3();
        animetor_PlayCharacter = GetComponent<AnimeCh>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        animetor_PlayCharacter.horizontal = moveVector.x;
        animetor_PlayCharacter.vertical = moveVector.y;
        moveVector *=moveSpeed;
        rigidbody2D.velocity = moveVector;
    }
}
