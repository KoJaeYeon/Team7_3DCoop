using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    public MyWeapon[] playerWeapons;
    public WeaponType weaponType;

    private void Awake()
    {
        //�÷��̾�Լ� weapon �������� �Ǵ� �Ҵ�
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
