using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    public MyWeapon[] playerWeapons;
    public WeaponType weaponType;

    Dictionary<WeaponType, WeaponData> weaponDataDic;

    private void Awake()
    {
        weaponDataDic = new Dictionary<WeaponType, WeaponData>();
        //플레이어에게서 weapon 가져오기 또는 할당
        weaponType = WeaponType.Revolver;

        //무기 설정 (공격속도, 총알속도, 공격력, 관통숫자, 폭발반지름, 폭발가능)
        weaponDataDic.Add(WeaponType.Revolver, new WeaponData(1f, 10f, 1f, 1, 0, false));
        weaponDataDic.Add(WeaponType.MachineGun, new WeaponData(0.3f, 15f, 2f, 1, 0, false));
        weaponDataDic.Add(WeaponType.RocketLauncer, new WeaponData(3f, 5f, 20f, 1, 2.5f, true));
        weaponDataDic.Add(WeaponType.SMG, new WeaponData(1f, 15f, 1f, 1, 0, false));
        weaponDataDic.Add(WeaponType.Rifle, new WeaponData(1f, 100f, 1f, 50, 0, false));
        weaponDataDic.Add(WeaponType.Bow, new WeaponData(1f, 10f, 1f, 2, 0, false));
        weaponDataDic.Add(WeaponType.ThorwingStars, new WeaponData(1f, 10f, 1f, 3, 0, false));
    }

    public void SetWeapon(WeaponType weaponType)
    {
        this.weaponType = weaponType;
        for(int i = 0; i < playerWeapons.Length; i++)
        {
            playerWeapons[i].SetWeapon(weaponType);
        }
    }

    public WeaponData GetWeaponData(WeaponType weaponType)
    {
        return weaponDataDic[weaponType];
    }
}

public struct WeaponData
{
    public float rapidSpeed { get; }
    public float bulletSpeed { get; }
    public float attackDamage { get; }
    public int piercing { get; }
    public float radius { get; }
    public bool explodeActive { get; }

    public WeaponData(float rapidSpeed, float bulletSpeed, float attackDamage, int piercing, float radius, bool explodeActive) : this()
    {
        this.rapidSpeed = rapidSpeed;
        this.bulletSpeed = bulletSpeed;
        this.attackDamage = attackDamage;
        this.piercing = piercing;
        this.radius = radius;
        this.explodeActive = explodeActive;
    }

}
