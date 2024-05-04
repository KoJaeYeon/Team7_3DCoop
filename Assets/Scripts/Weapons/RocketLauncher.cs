using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.RocketLauncher);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
