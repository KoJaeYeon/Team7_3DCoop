using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.Rifle);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
