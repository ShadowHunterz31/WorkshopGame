using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAMovement : MonoBehaviour
{

    private NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    public bool Chase(Transform target)
    {
        if (!target) return false;
        if (Vector3.Distance(transform.position,target.position)> nav.stoppingDistance)
        {
            nav.SetDestination(target.position);
            return true;
        }
        return false;
    }
}
