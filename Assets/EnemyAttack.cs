using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] int damage = 40;

    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (playerHealth == null)
        {
            return;
        }
        Debug.Log("bang bang");
        playerHealth.TakeDamage(damage);
    }
}
