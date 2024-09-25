using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickWeapon : MonoBehaviour
{
    private bool Pickded = false;
    void OnTriggerEnter2D(Collider2D  col){
       if(col.gameObject.GetComponent<PlayerControll>() !=null && Pickded==false){
            Pickded = true;
            Instantiate(gameObject, col.transform.position, col.transform.rotation);
            Destroy(gameObject);
       }
    }
    
}
