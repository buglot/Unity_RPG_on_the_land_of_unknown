using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ThrowingWeapon : WeaponBase
{
    public GameObject weapon;
    public void setTimeAttack(float a)
    {
        timeToAttack = a;
    }
    public Vector2 range;
    private bool canSpawnWeapon = true;
    public void setCanUse(bool a)
    {
        canSpawnWeapon = a;
    }
    public PlayerCharacter_Controller playmove;
    public StatusEffectbar statusEffectbar;
    public Enemy[] enemy2Ds;
    void Start()
    {
        playmove = GetComponentInParent<PlayerCharacter_Controller>();
        statusEffectbar = GameObject.FindAnyObjectByType<StatusEffectbar>();
    }
    List<Enemy> enemies;
    public UnityEvent OnSpawn;
    // Update is called once per frame
    bool isAttack = false;
    void Update()
    {
        // Increment the timer
        timer -= Time.deltaTime;
        if (timer < 0f && !isAttack)
        {
            return;
        }

        // Reset the timer once the attack time is reached
        if (isAttack)
        {
            timer = timeToAttack;
            isAttack = !isAttack;
            return;
        }


        // Perform the enemy detection
        Collider2D[] box = Physics2D.OverlapBoxAll(transform.position, range, 0);
        enemies = new List<Enemy>();
        foreach (Collider2D collider in box)
        {
            Enemy exp = collider.GetComponent<Enemy>();
            if (exp != null)
            {
                enemies.Add(exp);
            }
        }

        // Convert the enemies list to an array and check if there are any enemies
        enemy2Ds = enemies.ToArray();
        if (enemy2Ds.Length != 0)
        {
            SpawnWeapon();
        }
    }
    public StatusItemData effectview;
    void SpawnWeapon()
    {

        GameObject throw1;
        if (canSpawnWeapon)
        {
            throw1 = Instantiate<GameObject>(weapon);
            throw1.transform.position = playmove.transform.position;
            throw1.GetComponent<ThrowingProjectile>().setDirection(enemy2Ds);
            SetAll(throw1.GetComponent<Weapon>());

            addStutusEffect();
            isAttack = true;
            OnSpawn.Invoke();

        }

    }
    public void addStutusEffect(){
        effectview.time = timeToAttack;
        statusEffectbar.AddObject(effectview);
    }
    public override void Attack() { }
}
