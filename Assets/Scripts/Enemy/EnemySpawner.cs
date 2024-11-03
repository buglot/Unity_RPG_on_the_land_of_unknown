using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using UnityEngine;
using Random = UnityEngine.Random;
public enum TypeSpawnEnemy
{
    BOSS,
    Nomal
}
[Serializable]
public class RangeEnemy
{
    public int start;
    public int end;

}
[Serializable]
public class TimeManyEnemySetting
{
    public TypeSpawnEnemy type;
    public float time;
    public float timetoSpawn;
    public StageProgressData stagedata;
    public RangeEnemy rangeEnemy;
    public TimeManyEnemySetting(float time, float timetoSpawn, StageProgressData stagedata)
    {
        this.time = time;
        this.timetoSpawn = timetoSpawn;
        this.stagedata = stagedata;
    }
}
public class EnemySpawner : MonoBehaviour
{
    public EnemyData[] enemyDatas;
    public BOSSData[] BOSSDatas;
    public StageProgress stageProgress;
    public Transform player;
    public StageTime time1;
    public List<TimeManyEnemySetting> timeManyEnemySettings;
    [SerializeField] float spawnTimer;
    public Vector2 spawnArea;
    public float timer;
    public TypeSpawnEnemy nowtype;
    public GameObject boss;
    public GameObject BOSSBAR;
    RangeEnemy level;
    void Start()
    {
        Player player1 = GameObject.FindAnyObjectByType<Player>();
        player = player1.transform;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timeManyEnemySettings.Count > 0)
        {
            if (time1.time > timeManyEnemySettings[0].time && nowtype != TypeSpawnEnemy.BOSS)
            {
                nowtype = timeManyEnemySettings[0].type;
                spawnTimer = timeManyEnemySettings[0].timetoSpawn;
                stageProgress.progressPerSplit = timeManyEnemySettings[0].stagedata.progressPerSplit;
                stageProgress.progressTimeRate = timeManyEnemySettings[0].stagedata.progressTimeRate;
                level = timeManyEnemySettings[0].rangeEnemy;
                timeManyEnemySettings.Remove(timeManyEnemySettings[0]);
            }

        }


        if (timer < 0f)
        {
            Conditional(nowtype);
        }
    }

    private void Conditional(TypeSpawnEnemy nowtype)
    {
        switch (nowtype)
        {
            case TypeSpawnEnemy.Nomal:
                int random = Random.Range(level.start, DifficultLevel());
                SpawnEnemy(enemyDatas[random]);
                timer = spawnTimer;
                break;
            case TypeSpawnEnemy.BOSS:
                SpawnBOSS(BOSSDatas[0]);
                timer = float.PositiveInfinity;
                break;
        }
    }

    int DifficultLevel()
    {
        if (level.end > enemyDatas.Length)
        {
            level.end = enemyDatas.Length;
        }
        return (int)level.end;
    }
    void SpawnBOSS(BOSSData bossData){
        Vector3 localtionboss = new Vector3(70,70,0)+ player.transform.position;
        boss = Instantiate(bossData.prefeb);
        boss.transform.position = localtionboss;
        BossManger a =boss.GetComponent<BossManger>();
        
        BOSSBAR.SetActive(true);
        a.bossBase.HealthBar = BOSSBAR;
        a.bossBase.SethealthBar(BOSSBAR.GetComponent<HealthBar2D>());
        a.bossBase.SetState(bossData.state, bossData.enemyState);
        BOSSBAR.GetComponent<HealthBar2D>().UpdateHealthBar(a.bossBase.state.currentHealth, a.bossBase.state.maxHealth);
        a.bossBase.setSpawner(this);
        a.bossBase.item.setState(bossData.Itemstate);
    }
    void SpawnEnemy(EnemyData enemyData)
    {
        Vector3 position = getPositionGenerate();
        position += player.transform.position;

        GameObject enemy = Instantiate(enemyData.prefeb);
        EnemyManager enemyManager = enemy.GetComponent<EnemyManager>();
        enemyManager.SetState(enemyData.state);
        enemyManager.SetItemDrop(enemyData.Itemstate);
        enemyManager.UpdateStateForProgress(stageProgress.Progress);
        enemy.transform.position = position;
    }
    public Vector3 getPositionGenerate()
    {

        Vector3 position = new Vector3();
        float f = Random.value > 0.5f ? -1f : 1f;
        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {

            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;

        }
        position.z = 0;
        return position;
    }
}

