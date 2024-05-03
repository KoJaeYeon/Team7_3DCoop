using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public Transform bulletTrans;
    protected float rapidSpeed;
    protected float time;
    protected float bulletSpeed;
    protected float attackDamage = 1;
    protected int piercing = 1;
    protected float radius = 0;
    protected bool explodeActive = false;

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
            rigid.velocity = new Vector3(0, 0, bulletSpeed); // �Ѿ˼ӵ� ����
            bulletObject.transform.position = transform.position; // �Ѿ� ��ġ �ʱ�ȭ �÷��̾�� �� ��ġ �޾ƿ;���.
            Bullet bullet = bulletObject.GetComponent<Bullet>(); 
            bullet.InitBullet();
            bullet.SetBullet(attackDamage   ,piercing,radius,explodeActive);//�÷��̾� ���ݷ� �޾ƿ;���
            time = 0;
        }
    }
}
