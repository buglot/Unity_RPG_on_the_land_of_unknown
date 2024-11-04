using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossATKthrow : BossATKBase
{
    public bool isPlay = false;
    [SerializeField] Animator nomalAnime;
    [SerializeField] EnemyData slime_enemy;//slime_enemy.prefeb
    [SerializeField] Transform player;
    float timer;
    public float timeToAtk = 1f;
    int count = 0;
    void Awake()
    {
        player = GameObject.FindAnyObjectByType<Player>().transform;
    }
    public override void Cancel()
    {

    }

    public override void Clear()
    {
        isPlay = false;
        count = 0;
        timer = 0f;
    }

    public override void play()
    {
        isPlay = true;
        nomalAnime.Play("idle");
    }

    void Start()
    {

    }


    void Update()
    {
        if (isPlay)
        {
            if (timer < timeToAtk)
            {
                timer += Time.deltaTime;
                return;
            }
            count++;
            if (count > 15)
            {
                Clear();
                return;
            }
            GameObject slimeEnemyInstance = Instantiate(slime_enemy.prefeb, transform.position, Quaternion.identity);
            EnemyWalk enemyWalk = slimeEnemyInstance.GetComponent<EnemyWalk>();
            EnemyManager enemyManager = slimeEnemyInstance.GetComponent<EnemyManager>();
            Throw a = slimeEnemyInstance.GetComponent<Throw>();
            enemyWalk.isFollow = false;
            enemyManager.SetState(slime_enemy.state);
            // Calculate the direction to thee player
            Vector3 throwDirection = (player.transform.position - transform.position).normalized;
            a.oldPositon = player.transform.position;
            a.setDirection(throwDirection);
            a.speed = 10f;
            timer = 0f;
        }
    }

}
