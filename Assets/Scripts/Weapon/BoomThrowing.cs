using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomThrowing : ThrowingWeapon
{
    [SerializeField] private int number_throw = 3;
    public Vector2 limitrange;
    // Update is called once per frame
    void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }
        SpawnWeapon();
        timer = 0;
    }
    public Vector3 GetRandomVector2()
    {
        range.x = Random.Range(-limitrange.x, limitrange.x);
        range.y = Random.Range(-limitrange.y, limitrange.y);
        return new Vector3(range.x, range.y, 0);
    }
    void SpawnWeapon()
    {
        for (int x = 0; x < number_throw; x++)
        {
            GameObject throw1 = Instantiate<GameObject>(weapon);
            throw1.transform.position = playmove.transform.position;
            BoomProjectile boom = throw1.GetComponent<BoomProjectile>();
            boom.setDirection(GetRandomVector2() + playmove.transform.position);
            SetAll(throw1.GetComponent<Weapon>());
            addStutusEffect();
        }
    }
}
