using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    #region �翬�۾�����
    List<GameObject> bulletPools = new List<GameObject>();
    List<GameObject> enemyPools = new List<GameObject>();
    List<GameObject> itemBoxPools = new List<GameObject>();

    #endregion

    #region �������� �۾�����(����)

    #endregion
    #region �������� �۾�����(����)

    #endregion
    #region �������� �۾�����(�μ�)

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
