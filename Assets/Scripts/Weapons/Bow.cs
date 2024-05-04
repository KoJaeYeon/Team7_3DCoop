using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.Bow);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
