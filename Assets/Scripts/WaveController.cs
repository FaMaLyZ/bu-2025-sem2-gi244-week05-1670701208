using UnityEngine;

public class WaveController : MonoBehaviour
{
    public Wave currertWave;
    public Transform[] spawnPoints;

    private int enemySpawned = 0;
    private float nextSpawnTime = 0;

    void Update()
    {
        var t = Time.time;
        if (t > nextSpawnTime && enemySpawned < currertWave.enemyCount)
        {
            Spawn();
            enemySpawned++;
            nextSpawnTime = Time.time + currertWave.spawnInterval;
        }
    }

    void Spawn()
    {
        int enemyIndex = Random.Range(0, currertWave.enemyPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate
            (
            currertWave.enemyPrefabs[enemyIndex],
            spawnPoints[spawnPointIndex].position,
            currertWave.enemyPrefabs[enemyIndex].transform.rotation
            );
    }
    public void ChangeWave(Wave wave)
    {
        currertWave = wave;
        enemySpawned = 0;
        nextSpawnTime = Time.time;
    }
    public bool IsCompleted()
    {
        return enemySpawned >= currertWave.enemyCount;
    }
}
