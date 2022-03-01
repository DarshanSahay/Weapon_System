using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeaponView : MonoBehaviour             // the view class responsible for interaction and taking user input
{
    public WeaponType weaponType;
    public WeaponController controller;
    public Transform shootPoint;
    public Rigidbody bulletPrefab;
    public Text maxAmmoText;
    public Text ammoText;
    public Text magazineText;
    public Text weaponNameText;
    public bool currentlySelected = false;
    public bool isReloading = false;

    public event Action setStats = delegate { };
    public event Action onShoot = delegate { };
    public event Action onReloading = delegate { };

    void Start()
    {
        SetEvents();
        SetInstances();
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    void SetEvents()                                   // subscribing events on start
    {
        setStats += controller.SetWeaponStats;
        onShoot += controller.OnShooting;
        onReloading += controller.OnReloading;
        setStats?.Invoke();
    }
    private void OnDisable()                          // de-subscribing events on gameObject disabled
    {
        setStats -= controller.SetWeaponStats;
        onShoot -= controller.OnShooting;
        onReloading -= controller.OnReloading;
    }
    void SetInstances()                               // setting instances for UI
    {
        weaponType = controller._weaponType;
        maxAmmoText.text = (controller.maxAmmo).ToString();
        ammoText.text = (controller.ammoSize).ToString();
        magazineText.text = (controller.magazineSize).ToString();
        weaponNameText.text = controller.weaponName;
    }
    public void GetWeaponController(WeaponController _controller)             //get the weapon controller instance
    {
        controller = _controller;
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (controller.ammoSize <= 0 || (Input.GetKeyDown(KeyCode.R)))
        {
            isReloading = true;
            onReloading?.Invoke();
            return;
        }
        if(currentlySelected == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                onShoot?.Invoke();
                BulletPhysics();
            }
        }
        UpdateWeaponUI();
    }
    void BulletPhysics()                       //  how bullet should react after instantiation
    {
        Rigidbody bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity) as Rigidbody;
        bullet.velocity = new Vector3(0, 0, 25f);
    }
    public void UpdateWeaponUI()               // function to keep updating UI for weapon
    {
        ammoText.text = (controller.ammoSize).ToString();
        magazineText.text = (controller.magazineSize).ToString();
    }
}
