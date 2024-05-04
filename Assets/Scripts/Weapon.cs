using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField]
    protected float rapidSpeed;
    [SerializeField]
    protected float bulletSpeed;
    [SerializeField]
    protected float attackDamage = 1;
    [SerializeField]
    protected int piercing = 1;
    [SerializeField]
    protected float radius = 0;
    [SerializeField]
    protected bool explodeActive = false;
    protected float time;

    private void Start()
    {
        time = 0;
    }

    public virtual void Fire()
    {
        if (time > rapidSpeed)
        {
            Debug.Log("Fire");
            GameObject bulletObject = PoolManager.Instance.GetBullet();
            Rigidbody rigid = bulletObject.GetComponent<Rigidbody>();
            rigid.velocity = Vector3.zero;
            rigid.velocity = new Vector3(0, 0, bulletSpeed); // 총알속도 조절
            bulletObject.transform.position = transform.position; // MyWeapon 위치로 총알 발사
            Bullet bullet = bulletObject.GetComponent<Bullet>(); 
            bullet.InitBullet();
            bullet.SetBullet(attackDamage   ,piercing,radius,explodeActive);//플레이어 공격력 받아와야함
            time = 0;
        }
    }
}
