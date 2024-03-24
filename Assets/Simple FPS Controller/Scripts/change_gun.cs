using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_gun : MonoBehaviour
{
    public List<GameObject> guns; // List of gun prefabs
    private int currentGunIndex = 0; // Index of the current gun in the list
    public Weapon weapon1gun;
    public Weapon weapon2gun;

    private void Start()
    {
        // Disable all guns except the first one at the start
        for (int i = 0; i < guns.Count; i++)
        {
            if (i == currentGunIndex)
            {
                guns[i].SetActive(true);
                
            }
                
            else
            {
                guns[i].SetActive(false);
            }
                
        }
    }

    private void Update()
    {
        // Check for player input to switch guns
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchGun(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchGun(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && guns.Count >= 2)
        {
            SwitchGun(1);
        }
        // Add more conditions for additional guns (e.g., Alpha3 for the third gun, etc.)
    }

    private void SwitchGun(int index)
    {
        // Deactivate the current gun
        guns[currentGunIndex].SetActive(false);

        // Activate the new gun
        guns[index].SetActive(true);

        // Update the current gun index
        currentGunIndex = index;

        if(currentGunIndex == 0)
        {
            weapon1gun.ammoText.text = weapon1gun.ammo + "/" + weapon1gun.maxAmmo;
            weapon1gun.enabled = true;
            weapon2gun.enabled = false;
        }
        if(currentGunIndex == 1)
        {
            weapon2gun.ammoText.text = weapon2gun.ammo + "/" + weapon2gun.maxAmmo;
            weapon1gun.enabled = false;
            weapon2gun.enabled = true;
        }
        
    }
}
