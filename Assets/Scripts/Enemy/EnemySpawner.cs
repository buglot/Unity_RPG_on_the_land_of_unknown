using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
[Serializable]
public class TimeManyEnemySetting
{
    public float time;
    public float timetoSpawn;
    public StageProgressData stagedata;
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
    public StageProgress stageProgress;
    public Transform player;
    public StageTime time1;
    public List<TimeManyEnemySetting> timeManyEnemySettings;
    [SerializeField] float spawnTimer;
    public Vector2 spawnArea;
    float timer;
    public float level;
    public float Difficult
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
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
            if (time1.time > timeManyEnemySettings[0].time)
            {
                spawnTimer = timeManyEnemySettings[0].timetoSpawn;
                stageProgress.progressPerSplit = timeManyEnemySettings[0].stagedata.progressPerSplit;
                stageProgress.progressTimeRate = timeManyEnemySettings[0].stagedata.progressTimeRate;
                timeManyEnemySettings.Remove(timeManyEnemySettings[0]);
            }

        }


        if (timer < 0f)
        {
            int random = Random.Range(0, DifficultLevel());
            SpawnEnemy(enemyDatas[random]);
            timer = spawnTimer;
        }
    }
    int DifficultLevel()
    {
        if (level > enemyDatas.Length)
        {
            level = enemyDatas.Length;
        }
        return (int)level;
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

