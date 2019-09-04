using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int amount = 10;

    public int CurrentAmmo
    {
        get { return amount; }
    }

    public void ReduceCurrentAmmo()
    {
        amount--;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
