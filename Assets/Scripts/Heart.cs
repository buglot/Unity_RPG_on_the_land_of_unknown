using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
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
                b.AddBlood(health);
                _animator.SetTrigger("broke");
            }
                
        }
    }
}
