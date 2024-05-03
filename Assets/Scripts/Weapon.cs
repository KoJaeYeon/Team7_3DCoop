using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public Transform bulletTrans;
    protected float rapidSpeed;
    protected float time;
    protected float bulletSpeed;

    private void Start()
    {
        time = 0;
    }

    public virtual void Fire()
    {
        if (time > rapidSpeed)
        {
            Debug.Log("Fire");
            GameObject bullet = PoolManager.Instance.GetBullet();
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.velocity = Vector3.zero;
            rigid.velocity = new Vector3(0, 0, bulletSpeed); // 총알속도 조절
            bullet.transform.position = transform.position; // 총알 위치 초기화 플레이어에게 총 위치 받아와야함.
            time = 0;
        }
    }
}
