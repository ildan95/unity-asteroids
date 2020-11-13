using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private PlayerController controller;
    private List<IWeapon> weapons;

    private void Awake() {
        controller = GetComponent<PlayerController>();
        weapons = new List<IWeapon>(GetComponentsInChildren<IWeapon>());
    }

    private void Update() {
        if (controller.IsShooting){
            foreach (var weapon in weapons)
            {
                weapon.Shoot(); 
            }
        }
    }
}   
