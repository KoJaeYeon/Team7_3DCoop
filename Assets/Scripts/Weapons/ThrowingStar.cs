using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingStar : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.ThrowingStars);
    }
    public override void Fire()
    {
        if (time > weaponData.rapidSpeed)
        {
            StartCoroutine(ThrowStar());
            time = 0;
        }
    }
    
    IEnumerator ThrowStar()
    {
        ShootStars();
        yield return new WaitForSeconds(weaponData.rapidSpeed / 5);
        ShootStars();
        yield return new WaitForSeconds(weaponData.rapidSpeed / 5);
        ShootStars();
        yield break;
    }

    public void ShootStars()
    {
        GameObject bulletObject = PoolManager.Instance.GetStar();
        Rigidbody rigid = bulletObject.GetComponent<Rigidbody>();
        rigid.velocity = Vector3.zero;
        rigid.velocity = new Vector3(0, 0, weaponData.bulletSpeed); // �Ѿ˼ӵ� ����
        bulletObject.transform.position = transform.position; // MyWeapon ��ġ�� �Ѿ� �߻�
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.InitBullet();
        bullet.SetBullet(weaponData.attackDamage * WeaponManager.Instance.damageMultiplier, weaponData.piercing, weaponData.radius, weaponData.explodeActive);//�÷��̾� ���ݷ� �޾ƿ;���
    }
}
