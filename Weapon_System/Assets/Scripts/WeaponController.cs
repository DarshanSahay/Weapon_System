using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WeaponController                  // The controller class which handles the calculations for View Class
                                               // and data data from Model Class. 
{
    public WeaponView View { get; }            // getting the required instances
    public WeaponModel Model { get; }
    public WeaponService service;
    public WeaponType _weaponType;
    public int maxAmmo;
    public int ammoSize;
    public int magazineSize;
    public float reloadTime;
    public String weaponName;
    public WeaponController(WeaponModel model,WeaponView view)
    {
        Model = model;
        this.View = GameObject.Instantiate<WeaponView>(view);         //so that only correct object is Instantiated
        View.GetWeaponController(this);
    }
    public void SetWeaponStats()                                      // setting the stats for weapon
    {
        maxAmmo = WeaponService.Instance.controller.Model.MaxAmmo;
        ammoSize = WeaponService.Instance.controller.Model.Ammo;
        magazineSize = WeaponService.Instance.controller.Model.Magazine;
        reloadTime = WeaponService.Instance.controller.Model.ReloadTime;
        _weaponType = WeaponService.Instance.controller.Model.Type;
        weaponName = WeaponService.Instance.controller.Model.Name;
    }
    public void OnShooting()                                          // shooting the bullet and reducing ammo size
    {
        ammoSize--;
    }
    public void OnReloading()                                         // reloading funnction for weapon
    {
        reloadTime -= Time.deltaTime;
        if(reloadTime <= 0)
        {
            ammoSize = maxAmmo;
            View.isReloading = false;
            reloadTime = WeaponService.Instance.controller.Model.ReloadTime;
        }
    }
}
