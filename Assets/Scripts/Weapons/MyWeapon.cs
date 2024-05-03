using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum WeaponType 
{ 
    Revolver,
    MachineGun
}
public class MyWeapon : MonoBehaviour
{
    [SerializeField]
    private IWeapon weapon;
    public WeaponType myWeapon;

    private void Start()
    {
        InitWeapon();
    }
    private void OnEnable()
    {
        InitWeapon();
    }

    public void InitWeapon()
    {
        SetWeapon(WeaponManager.Instance.weaponType);
    }

    public void SetWeapon(WeaponType weaponType)
    {
        Debug.Log($"SetWeapon : {weaponType}");

        Component component = gameObject.GetComponent<IWeapon>() as Component;
        if (component != null) Destroy(component);

        switch (weaponType)
        {
            case WeaponType.Revolver:
                weapon = gameObject.AddComponent<Revolver>();
                break;
            case WeaponType.MachineGun:
                weapon = gameObject.AddComponent<MacineGun>();
                break;
        }
    }
    private void Update()
    {
        weapon.Fire();
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SetWeapon(WeaponType.MachineGun);
        }
    }
}
