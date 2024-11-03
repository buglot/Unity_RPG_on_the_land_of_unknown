using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossWalk : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform player;
    [SerializeField] private float moreFild;

    void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>().gameObject.transform;
    }
    public UnityEvent OnMove;
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > moreFild){
            OnMove.Invoke();
        }
    }
    float _speed;
    public float Speed{
        get { return _speed; }
        set{ _speed = value; }
    }
}
