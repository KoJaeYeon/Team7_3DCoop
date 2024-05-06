using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    #region 재연작업공간
    [Header("0.Bullet, 1.Rocket, 2.Rifle, 3.Arrow, 4.Star")]
    public GameObject[] bulletPrefab; //0.Bullet, 1.Rocket, 2.Rifle, 3.Arrow, 4.Star
    public GameObject enemyPrefab;
    public GameObject itemBoxPrefab;
    public GameObject particlePrefab;

    [Header("0.Bullet, 1.Rocket, 2.Rifle, 3.Arrow, 4.Star")]
    public Transform[] bulletTrans; //0.Bullet, 1.Rocket, 2.Rifle, 3.Arrow, 4.Star
    public Transform enemyTrans;
    public Transform itemBoxTrans;
    public Transform particleTrans;

    private int itemBoxCount = 30;

    Queue<GameObject>[] bulletPools;
    Queue<GameObject> enemyPools = new Queue<GameObject>();
    List<GameObject> itemBoxPools = new List<GameObject>();

    Queue<GameObject> particlePools = new Queue<GameObject>(); 

    #endregion

    #region 누군가의 작업공간(지혜)

    #endregion
    #region 누군가의 작업공간(준형)

    #endregion
    #region 누군가의 작업공간(민성)

    #endregion

    private void Awake()
    {
        bulletPools = new Queue<GameObject>[bulletPrefab.Length];
        for(int i = 0; i < bulletPrefab.Length; i++)
        {
            bulletPools[i] = new Queue<GameObject>();
        }

        for(int i = 0; i < 500; i++)//Bullet
        {
            GameObject prefab = Instantiate(bulletPrefab[0], bulletTrans[0]);
            prefab.SetActive(false);
            bulletPools[0].Enqueue(prefab);
        }

        for (int i = 0; i < 50; i++) //Rocket
        {
            GameObject prefab = Instantiate(bulletPrefab[1], bulletTrans[1]);
            prefab.SetActive(false);
            bulletPools[1].Enqueue(prefab);
        }

        for (int i = 0; i < 50; i++) //Rifle
        {
            GameObject prefab = Instantiate(bulletPrefab[2], bulletTrans[2]);
            prefab.SetActive(false);
            bulletPools[2].Enqueue(prefab);
        }

        for (int i = 0; i < 100; i++) //Arrow
        {
            GameObject prefab = Instantiate(bulletPrefab[3], bulletTrans[3]);
            prefab.SetActive(false);
            bulletPools[3].Enqueue(prefab);
        }

        for (int i = 0; i < 300; i++) //Star
        {
            GameObject prefab = Instantiate(bulletPrefab[4], bulletTrans[4]);
            prefab.SetActive(false);
            bulletPools[4].Enqueue(prefab);
        }
        for (int i = 0; i < 300; i++) //Enemy
        {
            GameObject prefab = Instantiate(enemyPrefab, enemyTrans);
            prefab.SetActive(false);
            enemyPools.Enqueue(prefab);
        }

        for (int i = 0; i < itemBoxCount; i++) //ItemBox
        {
            GameObject prefab = Instantiate(itemBoxPrefab, itemBoxTrans);
            prefab.SetActive(false);
            itemBoxPools.Add(prefab);
        }

        for (int i = 0; i < itemBoxCount; i++) //Particle
        {
            GameObject prefab = Instantiate(particlePrefab, particleTrans);
            prefab.SetActive(false);
            particlePools.Enqueue(prefab);
        }
    }
    public GameObject GetBullet()
    {
        GameObject bullet = bulletPools[0].Dequeue();
        bulletPools[0].Enqueue(bullet);
        bullet.SetActive(true);
        return bullet;
    }
    public GameObject GetRocket()
    {
        GameObject rocket = bulletPools[1].Dequeue();
        bulletPools[1].Enqueue(rocket);
        rocket.SetActive(true);
        return rocket;
    }
    public GameObject GetRifle()
    {
        GameObject rifle = bulletPools[2].Dequeue();
        bulletPools[2].Enqueue(rifle);
        rifle.SetActive(true);
        return rifle;
    }
    public GameObject GetArrow()
    {
        GameObject arrow = bulletPools[3].Dequeue();
        bulletPools[3].Enqueue(arrow);
        arrow.SetActive(true);
        return arrow;
    }
    public GameObject GetStar()
    {
        GameObject star = bulletPools[4].Dequeue();
        bulletPools[4].Enqueue(star);
        star.SetActive(true);
        return star;
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
                itemBox.SetActive(true);
                return itemBox;
            }
        }
        GameObject prefab = Instantiate(itemBoxPrefab, itemBoxTrans);
        itemBoxPools.Add(prefab);
        return prefab;
    }

    public GameObject GetPartivle()
    {
        GameObject particle = particlePools.Dequeue();
        particlePools.Enqueue(particle);
        particle.SetActive(true);
        return particle;
    }
}
