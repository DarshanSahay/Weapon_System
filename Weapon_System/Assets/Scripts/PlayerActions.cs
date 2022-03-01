using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour                      // this is a player class which interacts with weapon view class
{
    public WeaponType _wType;
    public Transform weaponHolder;
    public int selectedWeapon = 0;
    public int previousWeapon = 0;
    public bool inPickUpRange = false;

    private void Update()
    {
        SwitchWeapon();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropWeapon();
        }
    }
    private void OnTriggerStay(Collider other)                              // to check whether we collided with a weapon or not
    {
        if(other.gameObject.tag == "Weapon")
        {
            inPickUpRange = true;
            if (Input.GetKeyDown(KeyCode.F) && inPickUpRange == true)
            {
                PickUpWeapon();
            }
        }
        else
        {
            inPickUpRange = false;
        }
    }
    void SelectWeapon()                                      //  function to get the weapons in weapon holder and 
    {                                                        //  activating only the selected one
        foreach (Transform weapon in weaponHolder)
        {
            weapon.gameObject.SetActive(false);
        }
        previousWeapon = selectedWeapon;
        weaponHolder.GetChild(selectedWeapon).gameObject.SetActive(true);
        weaponHolder.GetChild(selectedWeapon).GetComponent<WeaponView>().currentlySelected = true;
        weaponHolder.GetChild(previousWeapon).GetComponent<WeaponView>().currentlySelected = false;
    }
    void PickUpWeapon()                                     // function to pick the weapon 
    {
        WeaponView view = GetComponent<WeaponView>();
        if(weaponHolder.childCount < 4)
        {
            view.transform.SetParent(weaponHolder);               //setting the parent of weapon to weaponHolder
        }
        else                                                      // pick and drop in case weaponholder is full 
        {
            if(view.weaponType == WeaponType.Secondary)               // check the weapon type and swap accordingly
            {
                Transform weaponToDrop = weaponHolder.GetChild(2);
                weaponToDrop.SetParent(null);
                view.transform.SetParent(weaponHolder);
            }
            else
            {
                Transform weaponToDrop = weaponHolder.GetChild(selectedWeapon);
                weaponToDrop.SetParent(null);
                view.transform.SetParent(weaponHolder);
            }
        }
    }
    void SwitchWeapon()                                       // function to switch between weapons based on keyboard buttons
    {   
        if(weaponHolder.childCount > 1)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedWeapon = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedWeapon = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedWeapon = 2;
            }
            SelectWeapon();
        }
    }
    void DropWeapon()                             // function to drop the selected weapon
    {
        Transform weaponToDrop = weaponHolder.GetChild(selectedWeapon);
        weaponToDrop.SetParent(null);
    }
}
