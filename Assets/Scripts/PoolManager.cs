using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    #region 재연작업공간
    List<GameObject> bulletPools = new List<GameObject>();
    List<GameObject> enemyPools = new List<GameObject>();
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
        bulletPools.Clear();
    }

    public GameObject GetEnemy()
    {
        GameObject gameObject = new GameObject();
        return gameObject;
    }

    public GameObject GetItemBox()
    {
        GameObject gameObject = new GameObject();
        return gameObject;
    }

    public GameObject GetBullet()
    {
        GameObject gameObject = new GameObject();
        return gameObject;
    }
    


}
