using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IACombat : MonoBehaviour
{
    [Header("Main Data")]
    private EnemyScriptable brain;

    [Header("Attack Info")]
    [SerializeField] private bool canAttack;
    [SerializeField] private float currentAttackCooldown;

    private NavMeshAgent nav;
    public void Init(EnemyScriptable pbrain)
    {
        brain = pbrain;
        nav = GetComponent<NavMeshAgent>();
        nav.stoppingDistance = brain.AttackRange;
    }
    public bool CheckAndAttack(Transform Target)
    {
        CooldownRecovery();
        if (Vector3.Distance(transform.position, Target.position) < brain.AttackRange)
        {
            if (canAttack)
            {
                Attack(Target);
            }
            return true;
        }
        return false;
    }
    public void CooldownRecovery()
    {

        currentAttackCooldown -= Time.deltaTime;
        if (currentAttackCooldown <= 0)
        {
            canAttack = true;
            currentAttackCooldown = brain.AttackSpeed;
        }
    }
    void Attack(Transform Target)
    {
        canAttack = false;
        Target.GetComponent<IDamageble>().TakeDamage(Random.Range(brain.AttackDamage[0], brain.AttackDamage[1]));
    }
}
