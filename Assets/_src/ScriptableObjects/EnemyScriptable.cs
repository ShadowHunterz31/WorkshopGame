using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemy",menuName ="ScriptableObjects/EnemyData",order = 0)]
public class EnemyScriptable : ScriptableObject
{
    [Header("Data")]
    public Status Status;


    [Header("CombatData")]
    public float AttackRange;
    public float AttackSpeed;
    public int[] AttackDamage;

    [Header("GFX")]
    public GameObject GFX;

}
