using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    // Start is called before the first frame update
    public int exp;
    private Player b;
    private Animator _animator;
    void Start(){
        _animator = GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other){
        b = other.gameObject.GetComponent<Player>();
        if (b != null)
        {
            if (b.blood > 0){
                b.AddEXP(exp);
                Destroy(gameObject);
            }
                
        }
    }
}
