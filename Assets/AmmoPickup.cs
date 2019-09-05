using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int amount = 5;
    [SerializeField] private AmmoType type = AmmoType.Bullets;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var ammo = FindObjectOfType<Ammo>();
            if (ammo)
            {
                ammo.IncreaseCurrentAmmo(type, amount);
                Destroy(gameObject);
            }
        }
    }
}
