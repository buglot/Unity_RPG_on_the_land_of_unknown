using UnityEngine;

public class ChildTriggerHandler : MonoBehaviour
{
    [SerializeField]private BossBase parentEnemy;

    private void Start()
    {
        parentEnemy = GetComponentInParent<BossBase>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
    }
}
