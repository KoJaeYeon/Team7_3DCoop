using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncer : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.RocketLauncer);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
