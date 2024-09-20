using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canWalk : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask layerMask1;
    
    public bool CanWalk(Vector3 a){
        if(Physics2D.OverlapCircle(a,0.2f,layerMask1)!=null){
            return false;
        }
        return true;
    }
}
