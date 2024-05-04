using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacineGun : Weapon,IWeapon
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
