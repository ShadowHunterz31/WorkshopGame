using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMovement : MonoBehaviour
{

    private NavMeshAgent nav;
    [Header("Enemy info")]
    public float AttackRange;
    public float AttackSpeed;
    public float currentAttackCooldown;
    public int[] AttackDamage;
    public bool canAttack;
    [Header("Player info")]
    public Transform Player;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = AttackRange;
    }


    void Update()
    {
        if (Player == null) return;
        Chase();
        if (Vector3.Distance(transform.position , Player.position) > AttackRange)
        {
            if (canAttack)
            {
                Attack();
            }
            else
            {
                currentAttackCooldown -= Time.deltaTime;
                if (currentAttackCooldown <= 0)
                {
                    canAttack = true;
                    currentAttackCooldown = AttackSpeed;
                }
            }
        }



    }
    void Attack()
    {
        canAttack = false;
        Player.GetComponent<IDamageble>().TakeDamage(Random.Range(AttackDamage[0], AttackDamage[1]));
    }
    void Chase()
    {
        nav.SetDestination(Player.position);
    }
}
