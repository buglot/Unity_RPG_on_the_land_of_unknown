using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;   
    public Transform player;          
    [SerializeField] float spawnTimer;
    public Vector2 spawnArea;
    float timer;
    public float level;
    public float Difficult {
        get{
           return level;
        }
        set{
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
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
    }
    int  DifficultLevel() {
        if (level > enemyPrefab.Length){
            level = enemyPrefab.Length;
        }
        return (int)level;
    }
    void SpawnEnemy()
    {
        Vector3 position = getPositionGenerate();
        position += player.transform.position;
        int random = Random.Range(0, DifficultLevel());
        GameObject enemy = Instantiate(enemyPrefab[random]);
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

