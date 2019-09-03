using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum EnemyState
{
    RESTING,
    PATROLLING,
    PROVOKED,
    ATACKING,
    DEATH,
}

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float aggroRange = 5f;
    [SerializeField] float turnSpeed = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    EnemyState state = EnemyState.RESTING;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (state == EnemyState.PROVOKED || state == EnemyState.ATACKING)
        {
            EngageTarget();
        }
        else if (distanceToTarget <= aggroRange)
        {
            state = EnemyState.PROVOKED;
        }
    }

    void EngageTarget()
    {
        FaceTarget();
        switch(state)
        {
            case EnemyState.PROVOKED:
                ChaseTarget();
                break;
            case EnemyState.ATACKING:
                AttackTarget();
                break;
        }
    }

    void ChaseTarget()
    {
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().SetBool("attack", false);
            GetComponent<Animator>().SetTrigger("move");
            navMeshAgent.SetDestination(target.position);
        }
        if (distanceToTarget < navMeshAgent.stoppingDistance)
        {
            state = EnemyState.ATACKING;
        }
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack", true);
        if (distanceToTarget > navMeshAgent.stoppingDistance)
        {
            state = EnemyState.PROVOKED;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
