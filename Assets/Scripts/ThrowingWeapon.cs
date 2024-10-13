using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThrowingWeapon : MonoBehaviour
{
    [SerializeField] private float timeAttack;
    float timer;
    [SerializeField] private GameObject throwing_weapon;
    public void setTimeAttack(float a)
    {
        timeAttack = a;
    }
    private bool canSpawnWeapon = true;
    public void setCanUse(bool a)
    {
        canSpawnWeapon = a;
    }
    PlayerCharacter_Controller playmove;
    Enemy2D[] enemy2Ds;
    void Start()
    {
        playmove = GetComponentInParent<PlayerCharacter_Controller>();
    }
    public UnityEvent OnSpawn;
    // Update is called once per frame
    void Update()
    {
        if (timer < timeAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        timer = 0;
        enemy2Ds = FindObjectsOfType<Enemy2D>();
        if(enemy2Ds.Length != 0){
            SpawnWeapon();
        }
        
    }
    void SpawnWeapon()
    {

        GameObject throw1;
        if (canSpawnWeapon)
        {
            throw1 = Instantiate<GameObject>(throwing_weapon);
            throw1.transform.position = playmove.transform.position;
            throw1.GetComponent<ThrowingProjectile>().setDirection(enemy2Ds);
            OnSpawn.Invoke();
          
        }

    }

}