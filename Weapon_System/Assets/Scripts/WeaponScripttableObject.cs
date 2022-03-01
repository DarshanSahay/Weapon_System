using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]
public class WeaponScripttableObject : ScriptableObject              // scriptable object for storing weapon data  
{
    public WeaponType weapon;
    public GameObject weaponPrefab;
    public string weaponName;
    public int maxAmmoSize;
    public int weaponAmmoSize;
    public int weaponMagazineSize;
    public float weaponReloadTime;
}
