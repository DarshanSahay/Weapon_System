using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModel                       // this is the model class which inherits data from scriptable objects
                                               // created for weapon and stores in there respective variables
{
    public WeaponType Type { get; }
    public GameObject Prefab { get; }
    public string Name { get; }
    public int MaxAmmo { get; }
    public int Ammo { get; }
    public int Magazine { get; }
    public float ReloadTime { get; }
    public WeaponModel(WeaponScripttableObject weaponData)
    {
        Type = weaponData.weapon;
        Prefab = weaponData.weaponPrefab;
        Name = weaponData.weaponName;
        MaxAmmo = weaponData.maxAmmoSize;
        Ammo = weaponData.weaponAmmoSize;
        Magazine = weaponData.weaponMagazineSize;
        ReloadTime = weaponData.weaponReloadTime;
    }
}
