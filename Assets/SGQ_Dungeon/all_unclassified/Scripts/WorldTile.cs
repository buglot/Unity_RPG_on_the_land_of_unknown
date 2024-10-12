using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class WorldTile : MonoBehaviour
{
   [SerializeField] Vector2Int tilePosition;
    void Start()
    {
        GetComponentInParent<WorldScolling>().Add(gameObject,tilePosition);
    
        transform.position = new Vector3(-100, -100 ,0);
    }

   
}
