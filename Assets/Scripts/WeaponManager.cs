using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    public MyWeapon[] playerWeapons;
    public WeaponType weaponType;

    private void Awake()
    {
        //플레이어에게서 weapon 가져오기 또는 할당
        weaponType = WeaponType.Revolver;
    }

    public void SetWeapon(WeaponType weaponType)
    {
        this.weaponType = weaponType;
        for(int i = 0; i < playerWeapons.Length; i++)
        {
            playerWeapons[i].SetWeapon(weaponType);
        }
    }
}
