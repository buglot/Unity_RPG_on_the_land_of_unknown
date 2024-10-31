using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomThrowing : ThrowingWeapon
{
    // Start is called before the first frame update
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
        Debug.Log(range.x.ToString()+"  "+ range.y.ToString());
        return new Vector3(range.x,range.y,0);
    }
    void SpawnWeapon()
    {
     
            GameObject throw1 = Instantiate<GameObject>(weapon);
            throw1.transform.position = playmove.transform.position;
            BoomProjectile boom = throw1.GetComponent<BoomProjectile>();
            boom.setDirection(GetRandomVector2()+playmove.transform.position);
            SetAll(throw1.GetComponent<Weapon>());

    }
}
