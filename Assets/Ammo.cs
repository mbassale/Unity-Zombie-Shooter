using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType type;
        public int amount;
    }

    [SerializeField] private AmmoSlot[] ammoSlots;

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = ammoSlots.First(slot => slot.type == ammoType);
        if (ammoSlot != null)
        {
            return ammoSlot.amount;
        }

        return 0;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int amount)
    {
        var ammoSlot = ammoSlots.First(slot => slot.type == ammoType);
        if (ammoSlot != null)
        {
            ammoSlot.amount += amount;
        }
    }

    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        var ammoSlot = ammoSlots.First(slot => slot.type == ammoType);
        if (ammoSlot != null)
        {
            ammoSlot.amount--;
        }
    }
}
