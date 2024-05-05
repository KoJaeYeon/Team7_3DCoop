using System.Collections;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public Transform[] itemSpawnTrans = new Transform[3];
    public Transform playerTrans;

    public float itemSpawnTimer = 5f;
    public float enemySpawnTimer = 1f;
    public float spawnSpeedMultiflier = 1f;

    private float enemyHelath = 1f;

    private int gameLevel;


    private void Start()
    {
        StartCoroutine(SpawnItem());
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnItem()
    {
        while (true)
        {
            yield return new WaitForSeconds(itemSpawnTimer);
            SpawnItemPoint();
        } 
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            SpawnEnemyPoint();
            yield return new WaitForSeconds(enemySpawnTimer * spawnSpeedMultiflier);
        }
    }
    public void SpawnItemPoint()
    {
        Debug.Log("Spawn");
        int count = Random.Range(1, 3); //1, 2
        if(count == 1)
        {
            PoolManager.Instance.GetItemBox().transform.position = itemSpawnTrans[Random.Range(0, 3)].position;
        }
        else // count = 2
        {
            int exceptNum = Random.Range(0, 3);
            for(int i = 0; i < 3; i++)
            {
                if (exceptNum == i) continue;
                PoolManager.Instance.GetItemBox().transform.position = itemSpawnTrans[i].position;
            }
        }
    }

    public void UpdateLevel(int level)
    {
        spawnSpeedMultiflier *= 0.9f;
        enemyHelath += 0.5f;
        enemyHelath *= 1.05f;
        gameLevel = level;
    }

    public void SpawnEnemyPoint()
    {
        Debug.Log("SpawnEnemy");
        GameObject prefab = PoolManager.Instance.GetEnemy();
        prefab.transform.position = itemSpawnTrans[1].position + Vector3.right * Random.Range(-5,5);
        prefab.transform.eulerAngles = new Vector3(0,-180,0);
        Enemy enemy = prefab.GetComponent<Enemy>();
        enemy.PlayerTransform = playerTrans;
        enemy.EnemyHp = enemyHelath;
    }

}
