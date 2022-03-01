using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponService : GenericSingleton<WeaponService>
{
    public WeaponScripttableObject[] weaponData;   
    public WeaponController controller;     
    public WeaponView view;
    public int noOfWeapons;               // set the value to how many weapons needs to be instantiated
    void Start()
    {
        for (int i = 0; i < noOfWeapons - 1; i++)
        {
            DeployWeapons();
        }
    }
    public WeaponController DeployWeapons()                 //binding up the weapon data and returning the controller
    {
        WeaponScripttableObject WeaponData = weaponData[Random.Range(0,weaponData.Length - 1)];
        WeaponModel Model = new WeaponModel(WeaponData);
        controller = new WeaponController(Model,view);
        return controller;
    }
}
