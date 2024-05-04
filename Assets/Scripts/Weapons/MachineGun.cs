using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon,IWeapon
{
    private void Start()
    {
        weaponData = WeaponManager.Instance.GetWeaponData(WeaponType.MachineGun);
    }
    public override void Fire()
    {
        base.Fire();
    }
}
