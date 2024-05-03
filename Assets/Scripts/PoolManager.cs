using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    #region 재연작업공간
    public GameObject bulletPrefab;
    public GameObject enemyPrefab;
    public GameObject itemBoxPrefab;

    public Transform bulletTrans;
    public Transform enemyTrans;
    public Transform itemBoxTrans;

    private int itemBoxCount = 30;

    Queue<GameObject> bulletPools = new Queue<GameObject>();
    Queue<GameObject> enemyPools = new Queue<GameObject>();
    List<GameObject> itemBoxPools = new List<GameObject>();

    #endregion

    #region 누군가의 작업공간(지혜)

    #endregion
    #region 누군가의 작업공간(준형)

    #endregion
    #region 누군가의 작업공간(민성)

    #endregion

    private void Awake()
    {
        for(int i = 0; i < 500; i++)
        {
            GameObject prefab = Instantiate(bulletPrefab, bulletTrans);
            prefab.SetActive(false);
            bulletPools.Enqueue(prefab);
        }
        for (int i = 0; i < 300; i++)
        {
            GameObject prefab = Instantiate(enemyPrefab, enemyTrans);
            prefab.SetActive(false);
            enemyPools.Enqueue(prefab);
        }

        for (int i = 0; i < itemBoxCount; i++)
        {
            GameObject prefab = Instantiate(itemBoxPrefab, itemBoxTrans);
            prefab.SetActive(false);
            itemBoxPools.Add(prefab);
        }
    }
    public GameObject GetBullet()
    {
        GameObject bullet = bulletPools.Dequeue();
        bulletPools.Enqueue(bullet);
        bullet.SetActive(true);
        return bullet;
    }
    public GameObject GetEnemy()
    {
        GameObject enemy = enemyPools.Dequeue();
        enemyPools.Enqueue(enemy);
        enemy.SetActive(true);
        return enemy;
    }

    public GameObject GetItemBox()
    {

        GameObject itemBox;
        for (int i = 0; i < itemBoxCount; i++)
        {
            if (!itemBoxPools[i].activeSelf)
            {
                itemBox = itemBoxPools[i];
                itemBox.SetActive(false);
                return itemBox;
            }
        }
        GameObject prefab = Instantiate(itemBoxPrefab, itemBoxTrans);
        itemBoxPools.Add(prefab);
        return prefab;
    }
}
