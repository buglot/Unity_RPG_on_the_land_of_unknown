using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMagnet : MonoBehaviour
{
    public GameObject magnet;
    public Transform player;
    [SerializeField] float spawnTimer;
    public Vector2 spawnArea;
    float timer;
    public float chance = 10f;
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
            float random = Random.Range(0f, 100f);
            if(random < chance){
                SpawnEnemy(magnet);
            }
            timer = spawnTimer;
        }
    }

    void SpawnEnemy(GameObject prefeb)
    {
        Vector3 position = getPositionGenerate();
        position += player.transform.position;

        GameObject magnet = Instantiate(prefeb);
        magnet.transform.position = position;
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
