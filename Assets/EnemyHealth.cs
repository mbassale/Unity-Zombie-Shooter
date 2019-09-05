using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    private bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
    }

    public void TakeDamage(int damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;
        var animator = GetComponent<Animator>();
        if (animator)
        {
            animator.SetTrigger("die");
        }
    }
}
